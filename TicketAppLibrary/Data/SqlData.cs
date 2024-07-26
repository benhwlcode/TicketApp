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
			(bool isSoldOut = false, bool isCompleted = false, string countryName = "")
		{
			string sql = "dbo.spEvents_ReturnAvailableEvents";

			var p = new
			{
				isSoldOut,
				isCompleted,
				countryName
			};

			return _db.LoadData<EventModel, dynamic>(sql, p, true, connectionName);

		}

	}
}
