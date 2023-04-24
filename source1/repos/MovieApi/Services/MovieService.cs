using System.Collections.Generic;
using System.Collections;
using MovieApi.Models;
using MovieApi.Repository;

namespace MovieApi.Services{
    
    public class MovieService: IMovieService {


        private IMovieRepository _repo;

        public MovieService(IMovieRepository repo){
            _repo = repo;

        }

        public IEnumerable<Movie1> GetMovies(){
            IEnumerable<Movie1> myList = _repo.GetAll();

            return myList;
        }
        public Movie1 GetMovieByName(string name){
            return _repo.GetMovieByName(name);
        }

        public Movie1 GetMovieByYear(int year){
            IEnumerable<Movie1> myList = _repo.GetAll();
            foreach(Movie1 m in myList){
                if(m.Year==year)
                    return m;
            }
            return null;
        }

        public void CreateMovie(Movie1 m){
            _repo.InsertMovie(m);
        }

        public void UpdateMovie(string name, Movie1 m){
            _repo.UpdateMovie(name,m);

        }

        public void DeleteMovie(string name){
            _repo.DeleteMovie(name);
        }

        
    }
}