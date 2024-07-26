using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAppLibrary.DataAccess
{
	public class SQLDataAccess : ISQLDataAccess
	{
		private readonly IConfiguration _config;

		public SQLDataAccess(IConfiguration config)
		{
			_config = config;
		}

		public void SaveData<T>
			(string sqlStatement, T parameter, bool isStoredProcedure,
				string connectionName)
		{
			string connectionString = _config.GetConnectionString(connectionName);

			CommandType commandType = DetermineCommandType(isStoredProcedure);

			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				connection.Execute(sqlStatement, parameter, commandType: commandType);
			}

		}

		public List<T> LoadData<T, U>
			(string sqlStatement, U parameter, bool isStoredProcedure,
				string connectionName)
		{
			string connectionString = _config.GetConnectionString(connectionName);

			CommandType commandType = DetermineCommandType(isStoredProcedure);

			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				List<T> rows = connection.Query<T>(sqlStatement, parameter, commandType: commandType)
					.ToList();

				return rows;
			}

		}

		private CommandType DetermineCommandType(bool isStoredProcedure)
		{
			CommandType output = CommandType.Text;

			if (isStoredProcedure == true)
			{
				output = CommandType.StoredProcedure;
				return output;
			}

			return output;
		}


	}
}
