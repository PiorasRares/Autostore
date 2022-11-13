using Materiale.Model;
using Materiale.View;

namespace Materiale;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App.LinieSelectata = e.CurrentSelection[0] as Linie;
    }
}

