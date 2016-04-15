using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using MyMusicApp.Models;

namespace MyMusicApp.DAL
{
    public class MusicInitialiser : DropCreateDatabaseIfModelChanges<MusicContext>
    {
        protected override void Seed(MusicContext context)
        {
            var artists = new List<Artist>
            {
                new Artist { FirstName = "Ed", LastName = "Sheeran" },
                new Artist { FirstName = "James", LastName = "Morrison" },
                new Artist { FirstName = "Paolo", LastName = "Nutini" },
                new Artist { FirstName = "Bill", LastName = "Withers" },
                new Artist { FirstName = "Frank", LastName = "Sinatra" }
            };
            artists.ForEach(s => context.Artists.Add(s));
            context.SaveChanges();

            var albums = new List<Album>
            {
                new Album { Title = "X", ArtistID = 1, Year = 2014, Price = 7.99M },
                new Album { Title = "+", ArtistID = 1, Year = 2011, Price = 6.95M },
                new Album { Title = "The Awakening", ArtistID = 2, Year = 2011, Price = 5.49M },
                new Album { Title = "Songs for You, Truths for Me", ArtistID = 2, Year = 2008, Price = 4.95M },
                new Album { Title = "Caustic Love", ArtistID = 3, Year = 2014, Price = 8.99M },
                new Album { Title = "These Streets", ArtistID = 3, Year = 2006, Price = 10.99M },
                new Album { Title = "Menagerie", ArtistID = 4, Year = 1977, Price = 6.99M },
                new Album { Title = "Still Bill", ArtistID = 4, Year = 1972, Price = 6.49M },
                new Album { Title = "Strangers in the Night", ArtistID = 5, Year = 1966, Price = 7.99M },
                new Album { Title = "My Way", ArtistID = 5, Year = 1969, Price = 12.99M }
            };
            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();
        }
    }
}
