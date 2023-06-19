using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Movie123.Model.Person;
using Movie123.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie123.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class PersonDetailViewModel : ObservableObject
    {
        /*Ezt a paramétert kapja az osztály az előző oldalról. Ez a kiválasztott film id-je.*/
        public int Id { get; set; }

        /*Ebbe a változóba kéri le a Service a személy részletei hívás eredményét, továbbá ennek a változonak a property-jeit jeleníti meg az oldalon.*/
        [ObservableProperty]
        PersonDetails personDetail = new PersonDetails();

        /*Ebbe a változóba kéri le a Service a személy filmbéli szerepei hívás eredményét, továbbá ennek a változonak a property-jeit jeleníti meg az oldalon.*/
        [ObservableProperty]
        PersonCombinedCredits personCombinedCredit = new PersonCombinedCredits();

        /*DI Service változó.*/
        private readonly IMovieService movieService;

        public PersonDetailViewModel(IMovieService ms)
        {
            movieService = ms;
        }

        /*Lekéri a személy részleteit*/
        public async void GetPersonDetailsAsync()
        {
            PersonDetail = await movieService.GetPersonDetailsAsync(Id);
        }

        /*Lekéri azokat a filmeket, amelyekben a személy szerepelt*/
        public async void GetPersonCombinedCreditsAsync()
        {
            PersonCombinedCredit = await movieService.GetPersonCombinedCreditsAsync(Id);
        }

        /*Akkor hívódik meg, amikor rányomnak egy filmre, amiben a személy szerepelt.
         Megkapja a kiválsztott film id-jét paraméterként.
         A megkapott id-re navigálja át a felhasználót a képernyőméretének megfelelő a filmet részletező oldalra.*/
        [RelayCommand]
        async Task Tap(int id)
        {
            if(DeviceDisplay.Current.MainDisplayInfo.Width > 1100) await Shell.Current.GoToAsync($"{nameof(MovieDetailPage)}?Id={id}");
            else await Shell.Current.GoToAsync($"{nameof(MovieDetailPageSmall)}?Id={id}");
        }

        /*Visszanavigálja a felhasználót a főoldalra.*/
        [RelayCommand]
        async Task NavBackHome()
        {
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }
    }
}
