using Movie123.ViewModel;

namespace Movie123.View;

public partial class TvDetailPageSmall : ContentPage
{
    TvDetailViewModel viewModel;
    public TvDetailPageSmall(TvDetailViewModel tdvm)
    {
        InitializeComponent();
        BindingContext = tdvm;
        viewModel = tdvm;
    }

    protected override void OnAppearing()
    {
        viewModel.GetTvDetailsAsync();
        viewModel.GetTvCreditsAsync();
        base.OnAppearing();
    }
}