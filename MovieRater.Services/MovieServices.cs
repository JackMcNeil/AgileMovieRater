using MovieRater.Data;
using MovieRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class MovieServices
    {
        private readonly Guid _userId;

        public MovieServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovie(MovieCreate model)
        {
            Movie movie = new Movie() { UserId = _userId, Title = model.Title, Description = model.Description, Genre = model.Genre, MaturityRating = model.MaturityRating };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(movie);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetMovies()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Movies.Where(e => e.UserId == _userId).Select(e => new MovieListItem { Title = e.Title, Description = e.Description, Genre = e.Genre, MaturityRating = e.MaturityRating, MovieId = e.MovieId });

                return query.ToArray();
            }
        }
    }
}
