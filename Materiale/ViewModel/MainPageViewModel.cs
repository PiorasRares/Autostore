using Materiale.Model;
using Materiale.View;
using System.ComponentModel;
using System.Windows.Input;

namespace Materiale.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Linie> Linii { get; set; }
        public List<ProdusInPlan> PlanInCurs { get; set; }
        public ICommand AddLinie { get; private set; }
        public ICommand AddProdus { get; private set; }
        public ICommand AdaugainPlan { get;private set; }
        public MainPageViewModel()
        {
            Linii = App.database.GetLinii().Result;
            PlanInCurs =
            AddLinie = new Command(
                    async execute=>
                    {
                        var rez = await Shell.Current.DisplayPromptAsync("Adauga o linie noua", "Numele liniei");
                        if (rez != null&& rez != "")
                        {
                            Linie linie = new Linie { NumeLinie = rez };
                            await App.database.AddLinie(linie);
                            Linii = App.database.GetLinii().Result;
                            OnPropertyChanged(nameof(Linii));
                            Shell.Current.SendBackButtonPressed();
                        }
                    }
                );
            AddProdus = new Command(
                    async execute=>
                    {
                       await Shell.Current.GoToAsync(nameof(AdaugaProdusPage));
                    }
                );
        }
    }
}
