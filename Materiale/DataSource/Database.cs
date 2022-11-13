using SQLite;
using Materiale.Model;

namespace Materiale.DataSource
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;
        public Database(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTablesAsync<Linie, Produs, Rola>();
        }
        //CRUD Linie
        public Task<List<Linie>> GetLinii()
        {
            return database.Table<Linie>().ToListAsync();
        }
        public Task<int> AddLinie(Linie linie)
        {
            return database.InsertAsync(linie);
        }
        public Task<int> DeleteLinie(int id)
        {
            return database.DeleteAsync(id);
        }
        //CRUD Produs
        public Task<List<Produs>> GetProduse(int IdLinie)
        {
            return database.Table<Produs>().Where(i=>i.IdLinie== IdLinie).ToListAsync();
        }
        public Task<int> AddProdus(Produs produs)
        {
            return database.InsertAsync(produs);
        }
        public Task<int> DeleteProdus(int Id)
        {
            return database.DeleteAsync(Id);
        }
        //CRUD Rola
        public Task<List<Rola>> GetRole(int IdProdus)
        {
            return database.Table<Rola>().Where(i=>i.IdProdus== IdProdus).ToListAsync();
        }
        public Task<int> AddRola(Rola rola)
        {
            return database.InsertAsync(rola);
        }
    }
}
