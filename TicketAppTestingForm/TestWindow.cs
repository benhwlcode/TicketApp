using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketAppLibrary.Data;
using TicketAppLibrary.DataAccess;

namespace TicketAppTestingForm
{
	public partial class TestWindow : Form
	{
		private readonly IDatabaseData _db;

		public TestWindow(ISQLDataAccess sQLDataAccess, IDatabaseData databaseData)
		{
			InitializeComponent();
		}

		private void InitializeAppSettings()
		{
			var services = new ServiceCollection();

			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			IConfiguration config = builder.Build();

			services.AddTransient<ISQLDataAccess, SQLDataAccess>();
			services.AddTransient<IDatabaseData, SqlData>();


		}

	}
}
