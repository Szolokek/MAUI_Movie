using Movie123.ViewModel;

namespace Movie123;

public partial class MainPage : ContentPage
{
	

	public MainPage(MainViewModel mvm)
	{
        BindingContext = mvm;
        InitializeComponent();
		
	}




}

