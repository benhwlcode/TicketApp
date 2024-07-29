using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketAppLibrary.Data;
using TicketAppLibrary.Models;

namespace TicketAppWeb.Pages.Ticket
{
    public class SearchEventsModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)]
        public bool IsSoldOut { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public bool IsCompleted { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public string Country { get; set; } = "";


        public List<EventModel> AvailableEvents { get; set; } = new List<EventModel>();


        public SearchEventsModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            AvailableEvents = 
                _db.ReturnAvailableEvents(IsSoldOut, IsCompleted, Country);
        }
    }
}
