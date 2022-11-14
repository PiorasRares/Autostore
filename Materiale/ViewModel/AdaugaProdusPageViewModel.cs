using Materiale.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace Materiale.ViewModel
{
    public class AdaugaProdusPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string numeprodus { get; set; }
        public string NumeProdus
        {
            get { return numeprodus; }
            set
            {
                numeprodus = value;
                OnPropertyChanged(nameof(NumeProdus));
            }
        }
        private bool toponly { get; set; }
        public bool TopOnly
        {
            get { return toponly; }
            set
            {
                toponly = value;
                TopVisible = !toponly; 
                OnPropertyChanged(nameof(TopVisible));
                OnPropertyChanged(nameof(TopOnly));
            }
        }
        public bool TopVisible { get; set; } = true;
        private string numepcb { get; set; }
        public string NumePCB
        {
            get { return numepcb; }
            set
            {
                numepcb = value;
                OnPropertyChanged(nameof(NumePCB));
            }
        }
        private int pcbpepanel { get; set; }
        public int PCBpePanel
        {
            get { return pcbpepanel; }
            set
            {
                pcbpepanel = value;
                OnPropertyChanged(nameof(PCBpePanel));
            }
        }
        private string numetop { get; set; }
        public string NumeTop
        {
            get { return numetop; }
            set
            {
                numetop = value;
                OnPropertyChanged(nameof(NumeTop)); 
            }
        }
        private string numeultimarola { get; set; }
        public string NumeUltimaRola
        {
            get { return numeultimarola; }
            set
            {
                numeultimarola = value;
                OnPropertyChanged(nameof(NumeUltimaRola));
            }
        }
        private string cantitateultima { get; set; }
        public string CantitateUltima
        {
            get { return cantitateultima;}
            set
            {
                cantitateultima= value;
                OnPropertyChanged(nameof(CantitateUltima));
            }
        }
        private string pepcbultima { get; set; }
        public string PePCBUltima
        {
            get { return pepcbultima; }
            set
            {
                pepcbultima= value;
                OnPropertyChanged(nameof(PePCBUltima));
            }
        }
        private string numerola { get; set; }
        public string NumeRola
        {
            get { return numerola; }
            set
            {
                numerola= value;
                OnPropertyChanged(nameof(NumeRola));
            }
        }
        private string cantitaterola { get; set; }
        public string CantitateRola
        {
            get { return cantitaterola;}
            set
            {
                cantitaterola= value;
                OnPropertyChanged(nameof(CantitateRola));
            }
        }
        private int cantitatepepanel { get; set; }
        public int CantitatePePanel
        {
            get { return cantitatepepanel;}
            set
            {
                cantitatepepanel= value;
                OnPropertyChanged(nameof(CantitatePePanel));
            }
        }
        public bool Confirm { get; set; } = false;
        public bool Buttoncheck { get; set; } = true;
        public List<Linie> Linii { get; set; }
        private Linie selectedpicker { get; set; }
        public Linie SelectedPicker
        {
            get { return selectedpicker; }
            set
            {
                selectedpicker= value;
                OnPropertyChanged(nameof(SelectedPicker));
            }
        }
        private int IdProdus { get; set; }
        private int ultimarolaid { get; set; }
        private Rola ultimar;
        public ICommand Check { get; private set; }
        public ICommand AdaugaRola { get;private set; }
        public ICommand StergeUltimaRola { get; private set; }
        public ICommand Salveaza { get;private set; }
        public AdaugaProdusPageViewModel()
        {
            Linii = App.database.GetLinii().Result;
            Check = new Command
                (
                    execute=>
                    {
                        if(SelectedPicker!= null)
                        {
                            if(TopOnly==true)
                            {
                                if(NumeProdus!=null&&NumePCB!=null&&PCBpePanel>0) 
                                {
                                     Produs produs = new Produs
                                     {
                                         NumeProdus = NumeProdus,
                                         PartPCB = NumePCB,
                                         PCBPePanel = PCBpePanel,
                                         IdLinie = SelectedPicker.Id
                                     };
                                    App.database.AddProdus(produs);
                                    IdProdus = App.database.UltimulProdusAdaugat().Result;
                                    Confirm = true; OnPropertyChanged(nameof(Confirm));
                                    Buttoncheck = false; OnPropertyChanged(nameof(Buttoncheck));    
                                }
                            }
                            else
                            {
                                if(NumeProdus!=null&&NumePCB!=null&&PCBpePanel>0&&NumeTop!=null) 
                                {
                                    Produs produs = new Produs
                                    {
                                        NumeProdus = NumeProdus,
                                        PartPCB = NumePCB,
                                        PCBPePanel = PCBpePanel,
                                        IdLinie = SelectedPicker.Id,
                                        NumeTop = NumeTop
                                    };
                                    App.database.AddProdus(produs);
                                    IdProdus = App.database.UltimulProdusAdaugat().Result;
                                    Confirm = true; OnPropertyChanged(nameof(Confirm));
                                    Buttoncheck = false; OnPropertyChanged(nameof(Buttoncheck));
                                }
                            }
                        }
                            
                    }
                );
            AdaugaRola = new Command(
                    async execute=>
                    {
                        if(CantitatePePanel>0&&NumeRola!=null&&int.Parse(CantitateRola)>0)
                        {
                            Rola rola = new Rola
                            {
                                CantitatePePCB = CantitatePePanel,
                                NumeRola = NumeRola,
                                CantitateRola = int.Parse(CantitateRola),
                                IdProdus = IdProdus
                            };
                            await App.database.AddRola(rola);
                            ultimarolaid = App.database.UltimulProdusAdaugat().Result;
                            var rola1 = App.database.GetLastRola(ultimarolaid).Result;
                            ultimar = new Rola { CantitatePePCB = rola1.CantitatePePCB, NumeRola = rola1.NumeRola, CantitateRola = rola1.CantitateRola, Id = rola1.Id,IdProdus = rola1.IdProdus };
                            NumeUltimaRola = ultimar.NumeRola;
                            PePCBUltima = ultimar.CantitatePePCB.ToString();
                            CantitateUltima = ultimar.CantitateRola.ToString();
                        }
                        CantitateRola = string.Empty;
                        CantitatePePanel = 0;
                        NumeRola = string.Empty;
                    }
                
                );
            StergeUltimaRola = new Command(
                    execute=>
                    {
                        App.database.DeleteRola(ultimar);
                        NumeUltimaRola = "";
                        PePCBUltima = "";
                        CantitateUltima = "";
                    }
                );
            Salveaza = new Command(
                    execute=>
                    {
                        Shell.Current.SendBackButtonPressed();
                    }
                );
        }
    }
}
