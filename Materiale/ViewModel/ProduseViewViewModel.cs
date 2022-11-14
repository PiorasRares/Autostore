using Materiale.Model;
using System.ComponentModel;

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

        public ProduseViewViewModel()
        {
            Produse = App.database.GetProduse(App.LinieSelectata.Id).Result;
        }
    }
}
