﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models
{
   public class ShowCreate
    {
        [Required]
        public  string Title { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string Season  { get; set; }
        public string Description { get; set; }
    }
}