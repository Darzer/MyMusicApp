﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
