using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApi.Models;
using MovieApi.Services;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        
        private readonly ILogger<MovieController> _logger;
        private IMovieService _service;

        public MovieController(ILogger<MovieController> logger,IMovieService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {   
            IEnumerable<Movie1> list =_service.GetMovies();
            if(list != null)
                return Ok(list);
            else
                return BadRequest();
        }

        [HttpGet("{name}", Name="GetMovie")]
        public IActionResult GetMoviesByName(string name)
        {   
            Movie1 obj=_service.GetMovieByName(name);
            if(obj!=null)
                return Ok(obj); 
            
            
            return BadRequest();
        }

        [HttpGet("year/")]

        public IActionResult GetMovieByYear(int year){

            Movie1 obj = _service.GetMovieByYear(year);
            if(obj!=null)
                return Ok(obj);
            
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie1 m){
            

            _service.CreateMovie(m);
            //add some code to determine if successful
            return CreatedAtRoute("GetMovie", new {name=m.Name}, m);
            
        }

        [HttpPut("{name}")]
        public IActionResult UpdateMovie(string name, Movie1 movieIn){

            _service.UpdateMovie(name, movieIn);
            
            return NoContent();
            
           
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteMovie(string name){
            _service.DeleteMovie(name);
            return NoContent();
        }
    }
}