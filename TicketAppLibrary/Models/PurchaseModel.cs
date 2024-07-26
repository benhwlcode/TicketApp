using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAppLibrary.Models
{
	public class PurchaseModel
	{
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int GuestId { get; set; }
        public int SeatsPurchased { get; set; }
        public string ConfirmationCode { get; set; }


    }
}
