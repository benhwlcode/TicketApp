using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAppLibrary.Models
{
	public class TicketModel
	{
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MaxSeatsCount { get; set; }
        public int SeatsSoldCount { get; set; }
        public int PerGuestLimit { get; set; }
        public string Description { get; set; }

    }
}
