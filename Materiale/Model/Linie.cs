using SQLite;

namespace Materiale.Model
{
    public class Linie
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string NumeLinie { get; set; }
    }
}
