using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Application.DTOs
{
    public class PieChartResponse
    {
        public decimal[] Series { get; set; }
        public string[] Labels { get; set; }
    }
}
