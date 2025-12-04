using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Models
{
    public class House
    {
        public int Id { get; set; }
        public string? Lot { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }
        public bool IsExclusive { get; set; }
        public bool IsMortagege { get; set; }
        public double Squeare { get; set; }
        public int NumOfRoms { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public int RegionId { get; set; }
    }
}
