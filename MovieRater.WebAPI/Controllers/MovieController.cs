using Microsoft.AspNet.Identity;
using MovieRater.Models;
using MovieRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRater.WebAPI.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            MovieServices noteService = CreateMovieService();
            var notes = noteService.GetMovies();
            return Ok(notes);
        }

        public IHttpActionResult Post(MovieCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMovieService();

            if (!service.CreateMovie(note))
                return InternalServerError();

            return Ok();
        }

        private MovieServices CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var MovieService = new MovieServices(userId);
            return MovieService;
        }
    }
}
