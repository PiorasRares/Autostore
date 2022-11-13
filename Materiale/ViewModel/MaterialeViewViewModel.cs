using Materiale.Model;
using System.ComponentModel;

namespace Materiale.ViewModel
{
    public class MaterialeViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Name { get; set; }
        public MaterialeViewViewModel()
        {
            Name = "Rares11f";
        }
    }
}
