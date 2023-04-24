using System.Collections.Generic;
using MovieApi.Models;

namespace MovieApi.Repository{
    public interface IMovieRepository{
        public IEnumerable<Movie1> GetAll();

        public Movie1 GetMovieByName(string name);

        public void InsertMovie(Movie1 m);

        public void UpdateMovie(string name,Movie1 m);

        public void DeleteMovie(string name);
    }
}







