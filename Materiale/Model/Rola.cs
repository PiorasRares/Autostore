using SQLite;

namespace Materiale.Model
{
    public class Rola
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int IdProdus { get; set; }
        public string NumeRola { get; set; }
        public int CantitateRola { get; set; }
        public int CantitatePePCB { get; set; }
    }
}
