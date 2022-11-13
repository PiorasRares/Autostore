using Materiale.View;

namespace Materiale;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute($"{nameof(AdaugaProdusPage)}",typeof(AdaugaProdusPage));
		Routing.RegisterRoute($"{nameof(MaterialeView)}", typeof(MaterialeView));
	}
}
