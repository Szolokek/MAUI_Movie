using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Movie123.Model.Tv;
using Movie123.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie123.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class TvDetailViewModel : ObservableObject
    {
        /*Ezt a paramétert kapja az osztály az előző oldalról. Ez a kiválasztott sorozat id-je.*/
        public int Id { get; set; }

        /*Ebbe a változóba kéri le a Service a sorozat részletei hívás eredményét, továbbá ennek a változonak a property-jeit jeleníti meg az oldalon.*/
        [ObservableProperty]
        TvDetails tvDetail = new TvDetails();

        /*Ebbe a változóba kéri le a Service a sorozat szereplői hívás eredményét, továbbá ennek a változonak a property-jeit jeleníti meg az oldalon.*/
        [ObservableProperty]
        TvCredits tvCredit = new TvCredits();

        /*DI Service változó.*/
        private readonly IMovieService movieService;

        public TvDetailViewModel(IMovieService ms)
        {
            movieService = ms;
        }

        /*Lekéri a sorozat részleteit*/
        public async void GetTvDetailsAsync()
        {
            TvDetail = await movieService.GetTvDetailsAsync(Id);
        }

        /*Lekéri a sorozat szereplőit*/
        public async void GetTvCreditsAsync()
        {
            TvCredit = await movieService.GetTvCreditsAsync(Id);
        }

        /*Akkor hívódik meg, amikor rányomnak egy szereplőre a sorozatból.
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
