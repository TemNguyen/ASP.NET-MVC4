﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC4.Models.ViewModel
{
    public class MovieFormViewModel
    {
        public ICollection<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}