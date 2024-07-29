using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketAppLibrary.Data;
using TicketAppLibrary.Models;

namespace TicketAppWeb.Pages.Ticket
{
    public class EventTickets : PageModel
    {
		private readonly IDatabaseData _db;

		[BindProperty(SupportsGet = true)]
		public int EventId { get; set; }

		[BindProperty(SupportsGet = true)]
		public EventFullModel EventFull { get; set; }

		public List<TicketModel> AvailableTickets { get; set; } = new List<TicketModel>();

		[BindProperty(SupportsGet = true)]
        public int TicketToPurchase { get; set; }

		public EventTickets(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            EventFull 
                = _db.ReturnFullEvent(EventId);

            AvailableTickets =
                _db.ReturnAvailableTickets(EventId);
        }

	}
}
