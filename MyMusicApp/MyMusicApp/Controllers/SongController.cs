using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMusicApp.DAL;
using MyMusicApp.Models;

namespace MyMusicApp.Controllers
{
    public class SongController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Song
        public ActionResult Index(string sortOrder)
        {
            ViewBag.SongSort = String.IsNullOrEmpty(sortOrder) ? "song_desc" : "";
            ViewBag.AlbumSort = sortOrder == "album_asc" ? "album_desc" : "album_asc";
            ViewBag.ArtistSort = sortOrder == "artist_asc" ? "artist_desc" : "artist_asc";
            ViewBag.DurationSort = sortOrder == "duration_asc" ? "duration_desc" : "duration_asc";
            var songs = from a in db.Songs.Include(a => a.Album).Include(a => a.Artist) select a;

            switch(sortOrder)
            {
                case "song_desc":
                    songs = songs.OrderByDescending(a => a.Title);
                    break;
                case "album_asc":
                    songs = songs.OrderBy(a => a.Album.Title);
                    break;
                case "album_desc":
                    songs = songs.OrderByDescending(a => a.Album.Title);
                    break;
                case "artist_asc":
                    songs = songs.OrderBy(a => a.Artist.FirstName).ThenBy(a => a.Artist.LastName);
                    break;
                case "artist_desc":
                    songs = songs.OrderByDescending(a => a.Artist.FirstName).ThenByDescending(a => a.Artist.LastName);
                    break;
                case "duration_asc":
                    songs = songs.OrderBy(a => a.TrackLength);
                    break;
                case "duration_desc":
                    songs = songs.OrderByDescending(a => a.TrackLength);
                    break;
                default:
                    songs = songs.OrderBy(a => a.Title);
                    break;

            }

            return View(songs.ToList());
        }

        // GET: Song/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Title");
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "ConcatNames");
            return View();
        }

        // POST: Song/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ArtistID,AlbumID,TrackLength")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Title", song.AlbumID);
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "ConcatNames", song.ArtistID);
            return View(song);
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Title", song.AlbumID);
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "ConcatNames", song.ArtistID);
            return View(song);
        }

        // POST: Song/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ArtistID,AlbumID,TrackLength")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Title", song.AlbumID);
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "ConcatNames", song.ArtistID);
            return View(song);
        }

        // GET: Song/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.Find(id);
            db.Songs.Remove(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
