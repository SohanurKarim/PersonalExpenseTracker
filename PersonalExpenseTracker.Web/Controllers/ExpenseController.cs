using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalExpenseTracker.Service.DTOs;
using PersonalExpenseTracker.Service.Interfaces;
using PersonalExpenseTracker.Web.ViewModels.Expense;

namespace PersonalExpenseTracker.Web.Controllers
{


    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseCategoryService _categoryService;

        public ExpenseController(
            IExpenseService expenseService,
            IExpenseCategoryService categoryService)
        {
            _expenseService = expenseService;
            _categoryService = categoryService;
        }

        //Here coding for list
        public async Task<IActionResult> Index()
        {
            var data = await _expenseService.GetAllAsync();

            var categories = await _categoryService.GetAllAsync();

            ViewBag.Categories = categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(data);
        }

        //Here coding for create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View();
        }

        //Here coding for create action
        [HttpPost]
        public async Task<IActionResult> Create(ExpenseCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllAsync();
                return View(model);
            }

            var dto = new ExpenseCreateDto
            {
                Title = model.Title,
                Amount = model.Amount,
                Date = model.Date,
                CategoryId = model.CategoryId,
                Notes = model.Notes,
                ReceiptFileName = model.ReceiptFile?.FileName // (simple version)
            };

            var result = await _expenseService.CreateAsync(dto);

            TempData[result.Success ? "Success" : "Error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
        //Here coding for Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        { 
           var result = await _expenseService.DetailsAsync(id);

            if (result == null)
            {
                TempData["Error"] = "Expense not found";
                return RedirectToAction(nameof(Index));
            }

            return View(result);
        }

        //Here coding for delete
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _expenseService.DeleteAsync(id);

            TempData[result.Success ? "Success" : "Error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }

        //Here coding for edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _expenseService.GetByIdAsync(id);

            if (data == null)
            {
                TempData["Error"] = "Expense not found";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = (await _categoryService.GetAllAsync())
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

            var model = new ExpenseEditVM
            {
                Id = data.Id,
                Title = data.Title,
                Amount = data.Amount,
                Date = data.Date,
                CategoryId = data.CategoryId,   
                Notes = data.Notes
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExpenseEditVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = (await _categoryService.GetAllAsync())
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    }).ToList();

                return View(model);
            }

            var dto = new ExpenseEditDto
            {
                Id = model.Id,
                Title = model.Title,
                Amount = model.Amount,
                Date = model.Date,
                CategoryId = model.CategoryId,
                Notes = model.Notes,
                ReceiptFileName = model.ReceiptFile?.FileName
            };

            var result = await _expenseService.UpdateAsync(dto);

            TempData[result.Success ? "Success" : "Error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
        //Here ajax coding search
        public async Task<IActionResult> Filter(string search, string categoryName, DateTime? fromDate, DateTime? toDate)
        {
            var expenses = await _expenseService.GetAllAsync();

            // Search by title
            if (!string.IsNullOrEmpty(search))
                expenses = expenses.Where(x => x.Title.Contains(search)).ToList();

            // Filter by CATEGORY NAME
            if (!string.IsNullOrEmpty(categoryName))
            {
                expenses = expenses
                    .Where(x => x.CategoryName != null &&
                                x.CategoryName.Trim().ToLower() == categoryName.Trim().ToLower())
                    .ToList();
            }

            // Date filters
            if (fromDate.HasValue)
                expenses = expenses.Where(x => x.Date >= fromDate).ToList();

            if (toDate.HasValue)
                expenses = expenses.Where(x => x.Date <= toDate).ToList();

            return PartialView("_ExpenseTable", expenses);
        }
    }
}