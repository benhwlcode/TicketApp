using TicketAppLibrary.Models;

namespace TicketAppLibrary.Data
{
	public interface IDatabaseData
	{
        public List<EventModel> ReturnAvailableEvents
            (bool isSoldOut, bool isCompleted, string countryName);
		public List<TicketModel> ReturnAvailableTickets(int eventId);
		public EventFullModel ReturnFullEvent(int eventId);
		public TicketModel ReturnTicketToPurchase(int ticketId);
		public void PurchaseTickets(TicketModel ticket, int seatsToPurchase,
			string firstName, string lastName, string phoneNumber, string emailAddress);

	}
}