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
            database.CreateTablesAsync<Linie, Produs, Rola,ProdusInPlan>();
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
        public Task<int> UltimulProdusAdaugat()
        {
            return database.ExecuteScalarAsync<int>("SELECT last_insert_rowid()");
        }
        public Task<int> AddProdus(Produs produs)
        {
            return database.InsertAsync(produs);
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
        public Task<Rola> GetLastRola(int id)
        {
            return database.Table<Rola>().Where(i => i.Id == id).FirstAsync();
        }
        public Task<int> DeleteRola(Rola rola)
        {
            return database.DeleteAsync(rola);
        }
        //CRUD ProdusInPlan
        public Task<List<ProdusInPlan>> ProduseInPlan(int id)
        {
            return database.Table<ProdusInPlan>().Where(i=>i.LinieId== id).ToListAsync();
        }
        public Task<int> AddProdusInPlan(ProdusInPlan produsInPlan)
        {
            return database.InsertAsync(produsInPlan);
        }
        public Task<List<ProdusInPlan>> InCurs()
        {
            return database.Table<ProdusInPlan>().Where(i=>i.Start>)
        }
    }
}
