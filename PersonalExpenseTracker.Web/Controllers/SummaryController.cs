using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracker.Service.Interfaces;

namespace PersonalExpenseTracker.Web.Controllers
{
    public class SummaryController : Controller
    {
        private readonly ISummaryService _service;

        public SummaryController(ISummaryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetSummaryAsync();
            return View(data);
        }
    }
}
