using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketAppLibrary.Data;

namespace TicketAppWeb.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly IDatabaseData _db;


		public IndexModel(ILogger<IndexModel> logger, IDatabaseData db)
		{
			_logger = logger;
			_db = db;
		}

		public void OnGet()
		{
			
		}
	}
}
