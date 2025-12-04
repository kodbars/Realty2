using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string? Fio { get; set; }
        public DateTime StartTitul { get; set; }
        public string? TypeTitul { get; set; }
        public string? NumTitul { get; set; }
        public DateTime? EndTitul { get; set; }
        public int HouseId { get; set; }
    }
}
