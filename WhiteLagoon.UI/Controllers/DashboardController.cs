using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Services.Interface;

namespace WhiteLagoon.UI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetTotalBookingRadialChartData()
        {
            var res = await _dashboardService.GetTotalBookingRadialChartData();

            return Json(res);
        }

        public async Task<IActionResult> GetRegisteredUserChartData()
        {
            var res = await _dashboardService.GetRegisteredUserChartData();

            return Json(res);
        }

        public async Task<IActionResult> GetRevenueChartData()
        {
            var res = await _dashboardService.GetRevenueChartData();

            return Json(res);
        }

        public async Task<IActionResult> GetBookingPieChartData()
        {
            var res = await _dashboardService.GetBookingPieChartData();

            return Json(res);
        }

        public async Task<IActionResult> GetMemberAndBookingLineChartData()
        {
            var res = await _dashboardService.GetMemberAndBookingLineChartData();

            return Json(res);
        }
    }
}
