using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAppLibrary.Models
{
	public class EventModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DetailsLink { get; set; }
        public int VenueId { get; set; }
        public DateOnly StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateOnly EndDate { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsSoldOut { get; set; }        
        public bool IsCompleted { get; set; }      


    }
}
