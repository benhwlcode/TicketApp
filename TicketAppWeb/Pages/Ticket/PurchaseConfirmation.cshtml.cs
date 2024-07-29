using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketAppLibrary.Data;

namespace TicketAppWeb.Pages.Ticket
{
    public class PurchaseConfirmationModel : PageModel
    {
		IDatabaseData _db;

		[BindProperty(SupportsGet = true)]
		public string EmailAddress { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ConfirmationCode { get; set; }


        public PurchaseConfirmationModel(IDatabaseData db)
		{
			_db = db;
		}

		public void OnGet()
        {
        }
    }
}
