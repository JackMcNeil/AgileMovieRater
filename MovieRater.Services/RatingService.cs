using MovieRater.Data;
using MovieRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(RatingsCreate model)
        {
            Ratings rating = new Ratings() {Rating = model.Rating, Comment = model.Comment, MovieId = model.MovieId, ShowId = model.ShowId };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(rating);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingsListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ratings.Where(e => e.UserId == _userId).Select(e => new RatingsListItem {Rating = e.Rating, Comment = e.Comment});

                return query.ToArray();
            }
        }
    }
}
