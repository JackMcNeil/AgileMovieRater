
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Ratings
    {
        [Key]
        public int RatingsId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [Range(0.0,5.0)]
        public double Rating { get; set; }
        [MinLength(2, ErrorMessage ="Comment is too short please enter at least 2 chracters")]
        public string Comment { get; set; }

        public int MovieId { get; set; }
        public int ShowId { get; set; }

    }
}
