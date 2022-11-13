using Materiale.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace Materiale.ViewModel
{
    public class AdaugaProdusPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Nume { get; set; }
        public AdaugaProdusPageViewModel()
        {
            Nume = "Rares";
        }
    }
}
