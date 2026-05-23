using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracker.Service.DTOs;
using PersonalExpenseTracker.Service.Interfaces;
using PersonalExpenseTracker.Web.ViewModels.Category;


namespace PersonalExpenseTracker.Web.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly IExpenseCategoryService _service;

        public ExpenseCategoryController(IExpenseCategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new CategoryCreateDto
            {
                Name = model.Name,
                Description = model.Description
            };

            var result = await _service.CreateAsync(dto);

            TempData[result.Success ? "Success" : "Error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            var model = new CategoryEditVM
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditVM model)
        {
            var dto = new CategoryEditDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            var result = await _service.UpdateAsync(dto);

            TempData[result.Success ? "Success" : "Error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            TempData[result.Success ? "Success" : "Error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
    }
}
