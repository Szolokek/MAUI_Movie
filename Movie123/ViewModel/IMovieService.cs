using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie123.Model.Movie;
using Movie123.Model.Person;
using Movie123.Model.Search;
using Movie123.Model.Tv;

namespace Movie123.ViewModel
{
    public interface IMovieService
    {
        //List
        /*Lekéri a megadott keresési string @param search_string eredményét és hogy hányadik oldalt szeretné lekérni a hívó. Tud személyt, filmet, és tv sorozatot is keresni.*/
        Task<ResultPage> MultiSearchAsync(string search_string, int page);
        /*Lekéri a legnépszerűbb filmeket a héten.*/
        Task<ResultPage> ListTopPopularAsync(int page);

        //Movies
        /*Lekéri egy adott id-vel rendelkező film részleteit*/
        Task<MovieDetails> GetMovieDetailsAsync(int id);
        /**Lekéri egy adott id-vel rendelkező film szereplőit*/
        Task<MovieCredits> GetMovieCreditsAsync(int id);

        //Tv Series
        /*Lekéri egy adott id-vel rendelkező tv sorozat részleteit*/
        Task<TvDetails> GetTvDetailsAsync(int id);
        /*Lekéri egy adott id-vel rendelkező tv sorozat szereplőit*/
        Task<TvCredits> GetTvCreditsAsync(int id);

        //Person
        /*Lekéri egy adott id-vel rendelkező személy részleteit*/
        Task<PersonDetails> GetPersonDetailsAsync(int id);
        /*Lekéri egy adott id-vel rendelkező személynek a filmeit*/
        Task<PersonCombinedCredits> GetPersonCombinedCreditsAsync(int id);
    }
}
