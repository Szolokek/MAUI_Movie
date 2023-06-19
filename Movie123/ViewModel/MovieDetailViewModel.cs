using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Movie123.Model.Movie;
using Movie123.View;

namespace Movie123.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class MovieDetailViewModel: ObservableObject
    {
        /*Ezt a paramétert kapja az osztály az előző oldalról. Ez a kiválasztott film id-je.*/
        public int Id { get; set; }
        
        /*Ebbe a változóba kéri le a Service a film részletei hívás eredményét, továbbá ennek a változonak a property-jeit jeleníti meg az oldalon.*/
        [ObservableProperty]
        MovieDetails movieDetail = new MovieDetails();

        /*Ebbe a változóba kéri le a Service a film szereplői hívás eredményét, továbbá ennek a változonak a property-jeit jeleníti meg az oldalon.*/
        [ObservableProperty]
        MovieCredits movieCredit = new MovieCredits();

        /*DI Service változó.*/
        private readonly IMovieService movieService;

        public MovieDetailViewModel(IMovieService ms)
        {
            movieService = ms;
        }

        /*Lekéri a film részleteit*/
        public async void GetMovieDetailsAsync()
        {
            MovieDetail =  await movieService.GetMovieDetailsAsync(Id);
        }

        /*Lekéri a film szereplőit*/
        public async void GetMovieCreditsAsync()
        {
            MovieCredit = await movieService.GetMovieCreditsAsync(Id);
        }

        /*Akkor hívódik meg, amikor rányomnak egy szereplőre a filmből.
         Megkapja a kiválsztott személy id-jét paraméterként.
         A megkapott id-re navigálja át a felhasználót a képernyőméretének megfelelő a személyt részletező oldalra.*/
        [RelayCommand]
        async Task Tap(int id)
        {
            if (DeviceDisplay.Current.MainDisplayInfo.Width > 1100) await Shell.Current.GoToAsync($"{nameof(PersonDetailPage)}?Id={id}");
            else await Shell.Current.GoToAsync($"{nameof(PersonDetailPageSmall)}?Id={id}");
        }

        /*Visszanavigálja a felhasználót a főoldalra.*/
        [RelayCommand]
        async Task NavBackHome()
        {
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }


    }
}
