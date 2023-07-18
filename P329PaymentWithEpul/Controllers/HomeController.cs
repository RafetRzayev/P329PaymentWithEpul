using Microsoft.AspNetCore.Mvc;
using P329PaymentWithEpul.Services;

namespace P329PaymentWithEpul.Controllers
{
    public class HomeController : Controller
    {
        private readonly EpulClient _epulClient;

        public HomeController(EpulClient epulClient)
        {
            _epulClient = epulClient;
        }

        public async Task<IActionResult> Index()
        {
           return View();
        }

        public async Task<IActionResult> CreateTransaction()
        {
            var response = await _epulClient.CreateTransaction(1, "test", Guid.NewGuid().ToString());

            return Redirect(response.ForwardUrl.ToString());
        }

        public async Task<IActionResult> CheckTransaction()
        {
            var orderId = HttpContext?.Request?.RouteValues?.Values?.ToList()?[2]?.ToString() ?? "";
            var isSuccess = await _epulClient.CheckTransaction(orderId);

            return View(isSuccess);
        }
    }
}