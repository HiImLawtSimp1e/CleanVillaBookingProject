using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.DTOs;

namespace WhiteLagoon.Application.Services.Interface
{
    public interface IDashboardService
    {
        Task<RadialBarChartResponse> GetTotalBookingRadialChartData();
        Task<RadialBarChartResponse> GetRegisteredUserChartData();
        Task<RadialBarChartResponse> GetRevenueChartData();
        Task<PieChartResponse> GetBookingPieChartData();
        Task<LineChartResponse> GetMemberAndBookingLineChartData();
    }
}
