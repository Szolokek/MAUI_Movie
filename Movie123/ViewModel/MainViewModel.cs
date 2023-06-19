using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Movie123.Model.Search;
using Movie123.View;

namespace Movie123.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        /*A népszerű filmek ezen oldalát kéri le, továbbá vezetve van, hogy éppen melyik oldalon jár a felhasználó*/
        private int page = 1;

        /*Dependency Injection MovieService*/
        private readonly IMovieService movieService;


        public MainViewModel(IMovieService ms)
        {
            movieService = ms;
        }

        /*Ebbe a változóba kéri le a népszerű filmeket*/
        private ResultPage rp = new ResultPage();

        /*Népszerű filmek listája*/
        [ObservableProperty]
        List<Movie> topList = new List<Movie>();

        /*Lekéri a Service osztálytól a népszerű filmek listáját*/
        [RelayCommand]
        public async void ListMovies()
        {
            rp = await movieService.ListTopPopularAsync(page);
            TopList = rp.results;
        }

        /*Lekéri a népszerű filmek következő oldalát*/
        [RelayCommand]
        public async void ListMoviesNextPage()
        {
            if (page < rp.total_pages) 
            {
                page++;
                rp = await movieService.ListTopPopularAsync(page);
                TopList = rp.results;
            }
            
        }

        /*Lekéri a népszerű filmek előző oldalát*/
        [RelayCommand]
        public async void ListMoviesPreviousPage()
        {
            if (page != 1)
            {
                page--;
                rp = await movieService.ListTopPopularAsync(page);
                TopList = rp.results;
            }
        }

        /*Ha egy filmre rányomnak a listában ez a függvény hívódik meg.
         Megkapja a kiválsztott film id-jét paraméterként.
         A megkapott id-re navigálja át a felhasználót a képernyőméretének megfelelő a filmet részletező oldalra.*/
        [RelayCommand]
        async Task Tap(int id)
        {
            if(DeviceDisplay.Current.MainDisplayInfo.Width > 1100) await Shell.Current.GoToAsync($"{nameof(MovieDetailPage)}?Id={id}");
            else await Shell.Current.GoToAsync($"{nameof(MovieDetailPageSmall)}?Id={id}");
        }

        /*A Search gomb megnyomására ez a függvény hívódik meg.
         Átnavigálja a felhasználót a kereső oldalra.*/
        [RelayCommand]
        async Task NavToSearch(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(SearchPage)}");
        }
    }
}
