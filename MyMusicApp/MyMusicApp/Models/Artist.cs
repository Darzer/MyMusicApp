using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Models
{
    public class Artist
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

        public string ConcatNames // Used to display Artists full name in the drop-down list on Create Album
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

    }
}
