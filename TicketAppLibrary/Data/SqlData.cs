using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TicketAppLibrary.DataAccess;
using TicketAppLibrary.Models;

namespace TicketAppLibrary.Data
{
	public class SqlData : IDatabaseData
	{
		private readonly ISQLDataAccess _db;
		private readonly string connectionName = "SqlDatabase";


		public SqlData(ISQLDataAccess db)
		{
			_db = db;
		}	

		public List<EventModel> ReturnAvailableEvents
			(bool isSoldOut, bool isCompleted, string countryName)
		{
			string sql = "spEvents_ReturnAvailableEvents";

			var p = new
			{
				isSoldOut,
				isCompleted,
				countryName
			};

			return _db.LoadData<EventModel, dynamic>(sql, p, true, connectionName);

		}

		public EventFullModel ReturnFullEvent(int eventId)
		{
			string sql = "dbo.spEvents_ReturnFullEvent";

			var p = new
			{
				eventId
			};

			return _db.LoadData<EventFullModel, dynamic>(sql, p, true, connectionName)
				.ToList().First();

		}

		public List<TicketModel> ReturnAvailableTickets(int eventId)
		{
			string sql = "dbo.spTickets_ReturnAvailableTickets";

			var p = new
			{
				eventId
			};

			return _db.LoadData<TicketModel, dynamic>(sql, p, true, connectionName);

		}

		public TicketModel ReturnTicketToPurchase(int ticketId) 
		{
			string sql = "dbo.spTickets_ReturnTicketById";

			var p = new
			{
				ticketId
			};

			return _db.LoadData<TicketModel, dynamic>(sql, p, true, connectionName)
				.ToList().First();
		}

		public void PurchaseTickets(TicketModel ticket, int seatsToPurchase, 
			string firstName, string lastName, string phoneNumber, string emailAddress)
		{

			int identificationId = 0;

			CreateIdentificationEntry(phoneNumber, emailAddress);
			identificationId = ReturnIdentificationId(phoneNumber, emailAddress);


			CreateGuestEntry(firstName, lastName, identificationId);

			int purchaseCount
				= seatsToPurchase + ReturnPreviousPurchasedAmount(ticket.Id, identificationId);

			if (CheckIfPurchaseCountWithinLimit(ticket.PerGuestLimit, 
				(ticket.MaxSeatsCount - ticket.SeatsSoldCount), purchaseCount))
			{
				PurchaseTickets(ticket.Id, identificationId, seatsToPurchase);
				UpdateSeatsSoldCount(seatsToPurchase, ticket.Id, ticket.EventId);

			}
			else
			{
				// error method
				return;
			}

		}

		private bool CheckIfUniqueIdentification(string phoneNumber, string emailAddress)
		{
			string sql = "dbo.spIdentifications_CheckIfUnique";

			var p = new
			{
				phoneNumber,
				emailAddress
			};

			var output =  _db.LoadData<int, dynamic>(sql, p, true, connectionName).ToList();

			if (output.Count == 0)
			{
				return true;
			}

			return false;

		}

		private void CreateIdentificationEntry(string phoneNumber, string emailAddress)
		{
			string sql = "dbo.spIdentifications_Insert";

			var p = new
			{
				phoneNumber,
				emailAddress
			};

			_db.SaveData(sql, p, true, connectionName);

		}

		private void CreateGuestEntry(string firstName, string lastName, int identificationId)
		{
			string sql = "dbo.spGuests_Insert";

			var p = new
			{
				firstName,
				lastName,
				identificationId
			};

			_db.SaveData(sql, p, true, connectionName);

		}

		private int ReturnIdentificationId(string phoneNumber, string emailAddress)
		{
			string sql = "dbo.spIdentifications_ReturnId";

			var p = new
			{
				phoneNumber,
				emailAddress
			};

			return _db.LoadData<int, dynamic>(sql, p, true, connectionName)
				.ToList().FirstOrDefault();
		}

		private int ReturnPreviousPurchasedAmount(int ticketId, int identificationId)
		{
			string sql = "spPurchases_ReturnPreviousPurchaseCount";

			var p = new
			{
				ticketId,
				identificationId
			};

			return _db.LoadData<int, dynamic>(sql, p, true, connectionName)
				.ToList().FirstOrDefault();

		}

		private bool CheckIfPurchaseCountWithinLimit
			(int limitCount, int remainingCount, int purchaseCount)
		{

			if (purchaseCount > limitCount || purchaseCount > remainingCount)
			{
				return false;
			}

			return true;
		}

		private void PurchaseTickets(int ticketId, int identificationId, int seatsPurchased)
		{
			string sql = "dbo.spPurchases_PurchaseTicket";

			string confirmationCode = Guid.NewGuid().ToString();

			var p = new
			{
				ticketId,
				identificationId,
				seatsPurchased,
				confirmationCode
			};

			_db.SaveData(sql, p, true, connectionName);
		}

		private void UpdateSeatsSoldCount(int seatsSold, int ticketId, int eventId)
		{
			string sql = "dbo.spTickets_UpdateTicketsSold";

			var p = new
			{
				seatsSold,
				ticketId,
				eventId
			};

			_db.SaveData(sql, p, true, connectionName);


		}



	}
}
