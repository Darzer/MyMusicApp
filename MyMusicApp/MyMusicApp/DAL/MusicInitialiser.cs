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
                new Artist { FirstName = "Paolo", LastName = "Nutini" }
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
                new Album { Title = "These Streets", ArtistID = 3, Year = 2006, Price = 10.99M }
            };
            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();

            var songs = new List<Song>
            {
                //Add songs for Ed Sheeran - X
                new Song { Title = "One", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 13) },
                new Song { Title = "I'm a Mess", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 06) },
                new Song { Title = "Sing", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 55) },
                new Song { Title = "Don't", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 39) },
                new Song { Title = "Nina", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 43) },
                new Song { Title = "Photograph", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 18) },
                new Song { Title = "Bloodstream", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 59) },
                new Song { Title = "Tenerife Sea", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 0) },
                new Song { Title = "Runaway", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 26) },
                new Song { Title = "The Man", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 41) },
                new Song { Title = "Thinking Out Loud", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 41) },
                new Song { Title = "Afire Love", AlbumID = 1, ArtistID = 1, TrackLength = new TimeSpan(0, 5, 14) },

                //Add songs for Ed Sheeran - +
                new Song { Title = "The A Team", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 19) },
                new Song { Title = "Drunk", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 20) },
                new Song { Title = "U.N.I.", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 49) },
                new Song { Title = "Grade 8", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 00) },
                new Song { Title = "Wake Me Up", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 49) },
                new Song { Title = "Small Bump", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 19) },
                new Song { Title = "This", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 16) },
                new Song { Title = "The City", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 54) },
                new Song { Title = "Lego House", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 05) },
                new Song { Title = "You Need Me, I Don't Need You", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 3, 39) },
                new Song { Title = "Kiss Me", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 4, 43) },
                new Song { Title = "Give Me Love / The Parting Glass", AlbumID = 2, ArtistID = 1, TrackLength = new TimeSpan(0, 8, 46) },

                //Add songs for James Morrison - The Awakening
                new Song { Title = "In My Dreams", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 4, 44) },
                new Song { Title = "6 Weeks", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 13) },
                new Song { Title = "I Won't Let You Go", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 49) },
                new Song { Title = "Up", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 38) },
                new Song { Title = "Slave to the Music", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 23) },
                new Song { Title = "Person I Should Have Been", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 46) },
                new Song { Title = "Say Something Now", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 4, 01) },
                new Song { Title = "Beautiful Life", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 2, 42) },
                new Song { Title = "Forever", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 41) },
                new Song { Title = "The Awakening", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 5, 10) },
                new Song { Title = "Right by Your Side", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 4, 59) },
                new Song { Title = "One Life", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 18) },
                new Song { Title = "All Around the World", AlbumID = 3, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 17) },

                //Add songs for James Morrison - Songs For You, Truths For Me
                new Song { Title = "The Only Night", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 37) },
                new Song { Title = "Save Yourself", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 01) },
                new Song { Title = "You Make It Real", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 31) },
                new Song { Title = "Please Don't Stop the Rain", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 54) },
                new Song { Title = "Broken Strings", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 4, 10) },
                new Song { Title = "Nothing Ever Hurt Like You", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 51) },
                new Song { Title = "Once When I Was Little", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 4, 42) },
                new Song { Title = "Precious Love", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 37) },
                new Song { Title = "If You Don't Wanna Love Me", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 4, 15) },
                new Song { Title = "Fix the World Up for You", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 35) },
                new Song { Title = "Dream on Hayley", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 33) },
                new Song { Title = "Love Is Hard", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 53) },
                new Song { Title = "Sitting on a Platform", AlbumID = 4, ArtistID = 2, TrackLength = new TimeSpan(0, 3, 05) },

                //Add songs for Paolo Nutini - Caustic Love
                new Song { Title = "Scream (Funk My Life Up)", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 09) },
                new Song { Title = "Let Me Down Easy", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 32) },
                new Song { Title = "Bus Talk (Interlude)", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 1, 30) },
                new Song { Title = "One Day", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 5, 06) },
                new Song { Title = "Numpty", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 54) },
                new Song { Title = "Superfly (Interlude)", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 1, 13) },
                new Song { Title = "Better Man", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 5, 29) },
                new Song { Title = "Iron Sky", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 6, 13) },
                new Song { Title = "Diana", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 35) },
                new Song { Title = "Fashion (Featuring Janelle Monae)", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 06) },
                new Song { Title = "Looking for Something", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 6, 21) },
                new Song { Title = "Cherry Blossom", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 6, 17) },
                new Song { Title = "Someone Like You", AlbumID = 5, ArtistID = 3, TrackLength = new TimeSpan(0, 2, 09) },

                //Add songs for Paolo Nutini - These Streets
                new Song { Title = "Jenny Don't Be Hasty", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 29) },
                new Song { Title = "Last Request", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 41) },
                new Song { Title = "Rewind", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 4, 19) },
                new Song { Title = "Million Faces", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 41) },
                new Song { Title = "These Streets", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 53) },
                new Song { Title = "New Shoes", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 3, 21) },
                new Song { Title = "White Lies", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 4, 00) },
                new Song { Title = "Loveing You", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 4, 00) },
                new Song { Title = "Autumn", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 2, 50) },
                new Song { Title = "Alloway Grove", AlbumID = 6, ArtistID = 3, TrackLength = new TimeSpan(0, 14, 12) }
            };
            songs.ForEach(s => context.Songs.Add(s));
            context.SaveChanges();
        }
    }
}
