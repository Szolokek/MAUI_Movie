using Movie123.ViewModel;

namespace Movie123.View;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel svm)
	{
		InitializeComponent();
		BindingContext = svm;
	}
}