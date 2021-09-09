using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Show
    {
        [Required]
        public  string Title  { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string  Rating  { get; set; }
        [Required]
        public int Season { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
