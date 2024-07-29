using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketAppLibrary.Data;
using TicketAppLibrary.Models;

namespace TicketAppWeb.Pages.Ticket
{
    public class PurchaseTicketsModel : PageModel
    {
        private readonly IDatabaseData _db;

		[BindProperty(SupportsGet = true)]
		public int TicketId { get; set; }


		[BindProperty(SupportsGet = true)]
		public TicketModel TicketToPurchase { get; set; }


		[BindProperty]
		public int SeatsToPurchase { get; set; }

		[BindProperty]
		public string FirstName { get; set; }

		[BindProperty]
		public string LastName { get; set; }

		[BindProperty]
		public string PhoneNumber { get; set; }

		[BindProperty]
		public string EmailAddress { get; set; }




        public PurchaseTicketsModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
			TicketToPurchase
				= _db.ReturnTicketToPurchase(TicketId);
		}

		public IActionResult OnPost()
		{
			TicketToPurchase
				= _db.ReturnTicketToPurchase(TicketId);

			_db.PurchaseTickets(TicketToPurchase, SeatsToPurchase,
				FirstName, LastName, PhoneNumber, EmailAddress);

			// error check here and determine confirmationcode

			var p = new
			{
				EmailAddress = this.EmailAddress,
				ConfirmationCode = "[Success]"
			};

			return RedirectToPage("/Ticket/PurchaseConfirmation", p);
		}
	}
}
