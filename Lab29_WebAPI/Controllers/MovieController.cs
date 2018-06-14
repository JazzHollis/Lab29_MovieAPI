using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab29_WebAPI.Models;
namespace Lab29_WebAPI.Controllers
{
    public class MovieController : ApiController
    {



        [HttpGet]  //Ques. #1
        public List<Movie> GetMovies()
        {
            MovieEntities ORM = new MovieEntities();

            return ORM.Movies.ToList();
        }



        [HttpGet]  //Ques. #2
        public List<string> GetMovieCategory()
        {
            MovieEntities ORM = new MovieEntities();

            return ORM.Movies.Select(c => c.Category).Distinct().ToList();
        }



        [HttpGet]  //Ques. #3
        public Movie GetRandomMovie()
        {

            MovieEntities ORM = new MovieEntities();

            Random r = new Random();
            List<Movie> MovieList = ORM.Movies.ToList();

            return MovieList[r.Next(0, MovieList.Count)];
        }




        [HttpGet]  //Ques. #4
        public Movie GetRandomMovieCategory(string randomCategory)
        {
            MovieEntities ORM = new MovieEntities();

            List<Movie> MovieList = ORM.Movies.Where(c => c.Category.Contains(randomCategory)).ToList();

            Random r = new Random();
            int random = r.Next(1, MovieList.Count());

            return MovieList[random];
        }


        [HttpGet] // Ques. #5
        public List<Movie> MovieRandomQuantity(int quantity)
        {
            MovieEntities ORM = new MovieEntities();
            Random r = new Random();
            List<Movie> Movies = ORM.Movies.ToList();
            List<Movie> MovieList = new List<Movie>();


            for (int i = 0; i <quantity;  i++)
            {
                int result = r.Next(MovieList.Count());
                MovieList.Add(MovieList[result]);
                MovieList.RemoveAt(result);
            }

            return Movies;
        }


        [HttpGet] // Ques. #6
        public List<string> MovieCategories()
        {
            MovieEntities ORM = new MovieEntities();
            return ORM.Movies.Select(c => c.Category).Distinct().ToList();

        }



        //[HttpGet] //Ques. #7
        //public List<Movie> MovieInfo(string info)
        //{
        //    MovieEntities ORM = new MovieEntities();

        //   List<Movie> title = ORM.Movies.Where(c => c.MovieTitle.Contains(info)).ToList();
            
        //    return 

        //}


        [HttpGet] //Ques. #8
        public List<Movie> MovieKeyword(string category)
        {
            MovieEntities ORM = new MovieEntities();

            return ORM.Movies.Where(c => c.Category.Contains(category)).ToList();

        }



    }
}
