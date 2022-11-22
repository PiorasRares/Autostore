using SQLite;

namespace Materiale.Model
{
    public class ProdusInPlan
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int LinieId { get;set; }
        public int ProdusId { get; set; }
        public string Name { get; set; }
        public int CantitateInPlan { get; set; }
        public TimeSpan Start { get;set; }
        public TimeSpan End { get;set; }    
    }
}
