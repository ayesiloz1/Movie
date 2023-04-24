using System.Collections.Generic;
using MovieApi.Models;
using MySql.Data.MySqlClient;
using System;
namespace MovieApi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private static readonly List<Movie1> movies = new List<Movie1>(10)
        {
            new Movie1 { Name = "Citizen Kane", Genre = "Drama", Year = 1941 },
            new Movie1 { Name = "The Wizard of Oz", Genre = "Fantasy", Year = 1939 },
            new Movie1 { Name = "The Godfather", Genre = "Crime", Year = 1972 }
        };
        private MySqlConnection _connection;

        public MovieRepository(){
            string connectionString="Server=localhost;userid=csci330user;password=csci330pass;database=entertainment";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        } 

        ~MovieRepository(){
            _connection.Close();
        }
        public IEnumerable<Movie1> GetAll()
        {
            var statement = "Select * from Movies";
            var command = new MySqlCommand(statement,_connection);
            var results = command.ExecuteReader();

        List<Movie1> newList = new List<Movie1>(20);

            while(results.Read()){
                Movie1 m =new Movie1{
                    Name =(string)results[1],
                    Genre=(string)results[3],
                    Year=(int)results[2]
                };
                newList.Add(m);
            }
            results.Close();
            return newList;
        }

        public Movie1 GetMovieByName(string name)
        {
            var statement = "Select * from Movies where Name =@newName";
            var command = new MySqlCommand(statement,_connection);
            command.Parameters.AddWithValue("@newName",name);
            var results = command.ExecuteReader();
            Movie1 m=null;
            if(results.Read()){
                 m = new Movie1{
                    Name =(string)results[1],
                    Genre=(string)results[3],
                    Year=(int)results[2]
                };
            }
            results.Close();
            return m;
        }

        public void InsertMovie(Movie1 m)
        {
            var statement = "INSERT INTO Movies(Name,Year,Genre) Values(@n,@y,@g)";
            var command = new MySqlCommand(statement,_connection);
            command.Parameters.AddWithValue("@n",m.Name);
            command.Parameters.AddWithValue("@y",m.Year);
            command.Parameters.AddWithValue("@g",m.Genre);


            int result = command.ExecuteNonQuery();

            Console.WriteLine(result);
        }

        public void UpdateMovie(string name, Movie1 movieIn)
        {
            var statement ="Update Movies Set Name=@newName,Year=@newYear,Genre=@newGenre Where Name=@updateName";
            var command = new MySqlCommand(statement,_connection);
            command.Parameters.AddWithValue("@newName",movieIn.Name);
            command.Parameters.AddWithValue("@newYear",movieIn.Year);
            command.Parameters.AddWithValue("@newGenre",movieIn.Genre);
            command.Parameters.AddWithValue("@updateName",name);

            int result = command.ExecuteNonQuery();
        }

        public void DeleteMovie(string name)
        {
            var statement = "DELETE FROM Movies WHERE Name=@deleteName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@deleteName", name);

            int result = command.ExecuteNonQuery();
        }
    }
}