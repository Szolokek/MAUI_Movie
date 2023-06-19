using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Movie123.Model.Search;
using Movie123.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie123.ViewModel
{
    public partial class SearchViewModel: ObservableObject
    {
        /*A keresés oldala. Továbbá tárolja, hogy melyik oldal lett utoljára lehívva.*/
        private int page = 1;

        /*Dependency Injection MovieService*/
        private readonly IMovieService movieService;

        /*Ezt írta be a felhasználó a keresőbe.*/
        [ObservableProperty]
        private string search_string = "";

        public SearchViewModel(IMovieService ms)
        {
            movieService = ms;
        }

        /*Ebbe a változóba kéri le a filmeket, sorozatokat, személyeket.*/
        ResultPage rp = new ResultPage();

        /*Találatok listája*/
        [ObservableProperty]
        List<Movie> results = new List<Movie>();

        /*Lekéri az adott keresési feltételre a filmeket, sorozatokat, személyeket.*/
        [RelayCommand]
        async Task GetSearchedMoviesAsync()
        {
            page = 1;
            rp = await movieService.MultiSearchAsync(Search_string, page);
            Results = rp.results;
        }

        /*Lekéri a következő oldalát a találatoknak.*/
        [RelayCommand]
        public async void GetSearchedMoviesNextPageAsync()
        {
            if (page < rp.total_pages)
            {
                page++;
                rp = await movieService.MultiSearchAsync(Search_string, page);
                Results = rp.results;
            }

        }

        /*Lekéri az előző oldalát a találatoknak.*/
        [RelayCommand]
        public async void GetSearchedMoviesPrevoiusPageAsync()
        {
            if (page != 1)
            {
                page--;
                rp = await movieService.MultiSearchAsync(Search_string, page);
                Results = rp.results;
            }
        }

        /*Visszanavigálja a felhasználót a főoldalra.*/
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }

        /*Ha egy filmre, sorozatra, személyre rányomnak a listában ez a függvény hívódik meg.
         Megkapja a kiválsztott teljes elemet paraméterként.
         A függvény ellenőrzi, hogy a kiválasztott elem film, sorozat vagy személy és az alapján navigál a megfelelő oldalra.
         Továbbá figyeli a felhasználó képoernyőjének a méretét, hogy a megfelelő nagyságú oldalra navigáljon.*/
        [RelayCommand]
        async Task Tap(Movie mv)
        {
            if (mv.media_type == "movie")
            {
                if (DeviceDisplay.Current.MainDisplayInfo.Width > 1100) await Shell.Current.GoToAsync($"{nameof(MovieDetailPage)}?Id={mv.id}");
                else await Shell.Current.GoToAsync($"{nameof(MovieDetailPageSmall)}?Id={mv.id}");
            }
            else if (mv.media_type == "tv")
            {
                if (DeviceDisplay.Current.MainDisplayInfo.Width > 1100) await Shell.Current.GoToAsync($"{nameof(TvDetailPage)}?Id={mv.id}");
                else await Shell.Current.GoToAsync($"{nameof(TvDetailPageSmall)}?Id={mv.id}");
            }
            else if (mv.media_type == "person") 
            {
                if (DeviceDisplay.Current.MainDisplayInfo.Width > 1100) await Shell.Current.GoToAsync($"{nameof(PersonDetailPage)}?Id={mv.id}");
                else await Shell.Current.GoToAsync($"{nameof(PersonDetailPageSmall)}?Id={mv.id}");
            }
        }
    }
}
