using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAppLibrary.Models
{
	public class VenueModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SeatCount { get; set; }
        public int AddressId { get; set; }
    }
}
