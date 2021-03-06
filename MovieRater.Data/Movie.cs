using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Movie
    {
        public int MovieId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string MaturityRating { get; set; }
    }
    
}
