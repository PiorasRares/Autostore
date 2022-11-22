using Java.Security;
using Materiale.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace Materiale.ViewModel
{
    public class ProduseViewViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<Produs> Produse { get; set; }   
        public List<ProdusInPlan> Plan { get; set; }
        public ICommand AddInPlan { get; private set; }
        Produs produsSelectat;
        public Produs ProdusSelectat
        {
            get { return produsSelectat; }
            set
            {
                if (produsSelectat != value)
                {
                    produsSelectat = value;
                }
            }
                
        }
        public string NumeLinie { get; set; }
        public ProduseViewViewModel()
        {
            Produse = App.database.GetProduse(App.LinieSelectata.Id).Result;
            Plan = App.database.ProduseInPlan(App.LinieSelectata.Id).Result;
            ProdusSelectat = new Produs();
            NumeLinie = App.LinieSelectata.NumeLinie;
            AddInPlan = new Command(
                    async execute=>
                    {
                        ProdusInPlan produs = new ProdusInPlan
                        {
                            CantitateInPlan = ProdusSelectat.CantitateInPlan,
                            LinieId = App.LinieSelectata.Id,
                            Name = ProdusSelectat.NumeProdus,
                            ProdusId = ProdusSelectat.Id,
                            Start = ProdusSelectat.OraStart,
                            End = ProdusSelectat.OraEnd
                        };
                        await App.database.AddProdusInPlan(produs);
                        Plan = App.database.ProduseInPlan(App.LinieSelectata.Id).Result;
                        OnPropertyChanged(nameof(Plan));
                    }
                );
        }
    }
}
