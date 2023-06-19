using Movie123.ViewModel;

namespace Movie123.View;

public partial class PersonDetailPageSmall : ContentPage
{
    PersonDetailViewModel viewModel;
    public PersonDetailPageSmall(PersonDetailViewModel pdvm)
    {
        InitializeComponent();
        BindingContext = pdvm;
        viewModel = pdvm;
    }

    protected override void OnAppearing()
    {
        viewModel.GetPersonDetailsAsync();
        viewModel.GetPersonCombinedCreditsAsync();
        base.OnAppearing();
    }
}