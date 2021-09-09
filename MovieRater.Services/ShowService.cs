using MovieRater.Data;
using MovieRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class ShowService
    {
        private readonly Guid _userId;

        public ShowService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShow(ShowCreate model)
        {
            Show show = new Show() { Title = model.Title, Description = model.Description, Genre = model.Genre, Rating = model.Rating, Season = model.Season };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(show);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Shows.Where(e => e.UserId == _userId).Select(e => new ShowListItem { Title = e.Title, Description = e.Description, Genre = e.Genre, Rating = e.Rating, Season = e.Season });

                return query.ToArray();
            }
        }
    }
}
