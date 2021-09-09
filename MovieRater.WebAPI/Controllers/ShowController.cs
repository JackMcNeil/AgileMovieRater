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
    public class ShowController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            ShowService noteService = CreateShowService();
            var notes = noteService.GetShows();
            return Ok(notes);
        }

        public IHttpActionResult Post(ShowCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.CreateShow(note))
                return InternalServerError();

            return Ok();
        }

        private ShowService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var showService = new ShowService(userId);
            return showService;
        }
    }
}
