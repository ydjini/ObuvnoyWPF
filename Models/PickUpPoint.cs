using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnoyWPF.Models
{
    public class PickUpPoint
    {
        public int Id { get; set; }
        public required string Index { get; set; }

        public required int CityId { get; set; }
        public City? City { get; set; }

        public required int StreetId { get; set; }
        public Street? Street { get; set; }

        public required int StreetNumber { get; set; }
    }
}
