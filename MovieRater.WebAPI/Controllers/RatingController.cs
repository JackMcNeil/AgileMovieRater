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
    public class RatingController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            RatingService noteService = CreateShowService();
            var notes = noteService.GetRatings();
            return Ok(notes);
        }

        public IHttpActionResult Post(RatingsCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.CreateRating(note))
                return InternalServerError();

            return Ok();
        }

        private RatingService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var showService = new RatingService(userId);
            return showService;
        }
    }
}
