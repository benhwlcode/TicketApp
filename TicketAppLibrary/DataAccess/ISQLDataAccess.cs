
namespace TicketAppLibrary.DataAccess
{
	public interface ISQLDataAccess
	{
		List<T> LoadData<T, U>(string sqlStatement, U parameter, bool isStoredProcedure, string connectionName);
		void SaveData<T>(string sqlStatement, T parameter, bool isStoredProcedure, string connectionName);
	}
}