using Movie123.ViewModel;

namespace Movie123.View;

public partial class MovieDetailPage : ContentPage
{
	public MovieDetailViewModel md;
	public MovieDetailPage(MovieDetailViewModel mdvm)
	{
		
		BindingContext = mdvm;
		md = mdvm;
        InitializeComponent();
    }

    protected override void OnAppearing()
	{
		md.GetMovieDetailsAsync();
		md.GetMovieCreditsAsync();
		base.OnAppearing();
	}
}