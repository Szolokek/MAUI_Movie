using Movie123.View;
using Movie123.ViewModel;

namespace Movie123;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(MovieDetailPage), typeof(MovieDetailPage));
		Routing.RegisterRoute(nameof(TvDetailPage), typeof(TvDetailPage));
		Routing.RegisterRoute(nameof(PersonDetailPage), typeof(PersonDetailPage));
		Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
		Routing.RegisterRoute(nameof(MovieDetailPageSmall), typeof(MovieDetailPageSmall));
		Routing.RegisterRoute(nameof(PersonDetailPageSmall), typeof(PersonDetailPageSmall));
		Routing.RegisterRoute(nameof(TvDetailPageSmall), typeof(TvDetailPageSmall));
	}
}
