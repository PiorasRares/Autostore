using Materiale.DataSource;
using Materiale.Model;
namespace Materiale;

public partial class App : Application
{
	private static Database _db;
	public static Database database
	{
		get
		{
			if (_db == null)
			{
				_db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3"));
			}
			return _db;
		}
	}
	public static Linie LinieSelectata { get; set; }
	public static Produs ProdusSelectat { get; set; }
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
