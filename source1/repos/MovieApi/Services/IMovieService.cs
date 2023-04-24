using System.Collections.Generic;
using MovieApi.Models;

namespace MovieApi.Services{
    public interface IMovieService{

        public IEnumerable<Movie1> GetMovies();

        public Movie1 GetMovieByName(string name);

        public Movie1 GetMovieByYear(int year);

        

        public void CreateMovie(Movie1 m);

        public void UpdateMovie(string name, Movie1 m);

        public void DeleteMovie(string name);
    }
}