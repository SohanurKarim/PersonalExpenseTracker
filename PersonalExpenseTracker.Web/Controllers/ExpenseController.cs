using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var data = await _expenseService.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View();
        }

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

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _expenseService.DeleteAsync(id);

            TempData[result.Success ? "Success" : "Error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
    }
}
