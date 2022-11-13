using SQLite;

namespace Materiale.Model
{
    public class Produs
    {
        [PrimaryKey,AutoIncrement]  
        public int Id { get; set; }
        public int IdLinie { get; set; }
        public string NumeProdus { get; set; }
        public bool TopOnly { get; set; }
        public string NumeTop { get; set; }
        public string PartPCB { get; set; }
        public int PCBPePanel { get; set; }

    }
}
