namespace Jshop.Backend.Areas.Backoffice.Controllers
{
    using Jshop.Backend.Data;
    using Microsoft.AspNetCore.Mvc;

    [Area("Backoffice")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}