using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using Movie123.Model.Movie;
using Movie123.Model.Person;
using Movie123.Model.Search;
using Movie123.Model.Tv;

namespace Movie123.ViewModel
{
    public class MovieService: IMovieService
    {
        private readonly HttpClient http;

        /*Ezzel a kulccsal lehet használni az API-t*/
        private readonly string api_key = "cb81f7c9f32c4d72cb9d2fcf8e25349c";

        /*Minden API hívás ezzel kezdődik ezért kiszerveztem az URI elejét*/
        private readonly string site = "https://api.themoviedb.org/3";
        public MovieService()
        {
            this.http = new HttpClient();
        }

        /*Lekéri a megadott keresési string @param search_string eredményét és hogy hányadik oldalt szeretné lekérni a hívó. Tud személyt, filmet, és tv sorozatot is keresni.*/
        public async Task<ResultPage> MultiSearchAsync(string search_string, int page)
        {
            try
            {
                string uri = Uri.EscapeDataString(search_string);
                var result = await http.GetFromJsonAsync<ResultPage>(site + "/search/multi?api_key=" + api_key + "&language=en-US&query=" + uri + "&page=" + page + "&include_adult=false");
                return result;
            }
            catch
            {
                await Shell.Current.DisplayAlert("Something went wrong!", "", "Ok");
                return new ResultPage(); 
            }
            
        }

        /*Lekéri a legnépszerűbb filmeket a héten.*/
        public async Task<ResultPage> ListTopPopularAsync(int page)
        {
            try
            {
                var result = await http.GetFromJsonAsync<ResultPage>(site + "/movie/popular?api_key=" + api_key + "&language=en-US&page=" + page);
                return result;
            }
            catch
            {
                await Shell.Current.DisplayAlert("Something went wrong!", "", "Ok");
                return new ResultPage();
            }

        }

        /*Lekéri egy adott id-vel rendelkező film részleteit*/
        public async Task<MovieDetails> GetMovieDetailsAsync(int id)
        {
            try
            {
                var result = await http.GetFromJsonAsync<MovieDetails>(site + "/movie/" + id + "?api_key=" + api_key + "&language=en-US");
                return result;
            }
            catch
            {
                await Shell.Current.DisplayAlert("Something went wrong!", "", "Ok");
                return new MovieDetails();
            }
        }

        /**Lekéri egy adott id-vel rendelkező film szereplőit*/
        public async Task<MovieCredits> GetMovieCreditsAsync(int id)
        {
            try
            {
                var result = await http.GetFromJsonAsync<MovieCredits>(site + "/movie/" + id + "/credits?api_key=" + api_key + "&language=en-US");
                return result;
            }
            catch {
                await Shell.Current.DisplayAlert("Something went wrong!", "", "Ok");
                return new MovieCredits(); }
            
        }

        /*Lekéri egy adott id-vel rendelkező tv sorozat részleteit*/
        public async Task<TvDetails> GetTvDetailsAsync(int id)
        {
            try
            {
                var result = await http.GetFromJsonAsync<TvDetails>(site + "/tv/" + id + "?api_key=" + api_key + "&language=en-US");
                return result;
            }
            catch {
                await Shell.Current.DisplayAlert("Something went wrong!", "", "Ok");
                return new TvDetails(); }
        }

        /*Lekéri egy adott id-vel rendelkező tv sorozat szereplőit*/
        public async Task<TvCredits> GetTvCreditsAsync(int id)
        {
            try 
            {
                var result = await http.GetFromJsonAsync<TvCredits>(site + "/tv/" + id + "/credits?api_key=" + api_key + "&language=en-US");
                return result;
            }
            catch {
                await Shell.Current.DisplayAlert("Something went wrong!", "", "Ok");
                return new TvCredits(); }
            
        }

        /*Lekéri egy adott id-vel rendelkező személy részleteit*/
        public async Task<PersonDetails> GetPersonDetailsAsync(int id)
        {
            try
            {
                var result = await http.GetFromJsonAsync<PersonDetails>(site + "/person/" + id + "?api_key=" + api_key + "&language=en-US");
                return result;
            }
            catch {
                await Shell.Current.DisplayAlert("Something went wrong!", "", "Ok");
                return new PersonDetails(); }
        }

        /*Lekéri egy adott id-vel rendelkező személynek a filmeit*/
        public async Task<PersonCombinedCredits> GetPersonCombinedCreditsAsync(int id)
        {
            try
            {
                var result = await http.GetFromJsonAsync<PersonCombinedCredits>(site + "/person/" + id + "/combined_credits?api_key=" + api_key + "&language=en-US");
                return result;
            }
            catch {
                await Shell.Current.DisplayAlert("Something went wrong!", "", "Ok");
                return new PersonCombinedCredits(); }
        }
    }
}
