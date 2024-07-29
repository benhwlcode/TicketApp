using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAppLibrary.Models
{
	public class EventFullModel
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string DetailsLink { get; set; }

        public DateOnly StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeSpan EndTime { get; set; }

        public string VenueName { get; set; }
        public string AddressStreet { get; set; }
        public string AddressMunicipal { get; set; }
        public string AddressCountry { get; set; }



    }
}
