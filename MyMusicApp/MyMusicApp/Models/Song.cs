using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Models
{
    public class Song
    {
        public int ID { get; set; }
        [Display(Name = "Song")]
        public string Title { get; set; }
        public int AlbumID { get; set; }
        [Display(Name = "Duration")]
        public TimeSpan TrackLength { get; set; }
        public virtual Album Album { get; set; }
    }
}
