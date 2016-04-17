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
using PagedList;

namespace MyMusicApp.Controllers
{
    public class AlbumController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Album
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.AlbumSort = String.IsNullOrEmpty(sortOrder) ? "album_desc" : "";
            ViewBag.ArtistSort = sortOrder == "artist_asc" ? "artist_desc" : "artist_asc";
            ViewBag.YearSort = sortOrder == "year_asc" ? "year_desc" : "year_asc";
            ViewBag.PriceSort = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var albums = from a in db.Albums.Include(a => a.Artist) select a;
            //I realised that the above code worked without the .Include but further research told me that with .Include 
            //EF will use a join to grab both the Album and Artist tables in a single query. Without Include, 
            //EF will only grab Album and then grab Artist on demand which in most cases would be a hindrance to performance.

            if (!String.IsNullOrEmpty(searchString))
            {
                
                albums = albums.Where(a => a.Title.ToUpper().Contains(searchString.ToUpper())
                                                ||
                String.Concat(a.Artist.FirstName + " " +  a.Artist.LastName).ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "album_desc":
                    albums = albums.Include(a => a.Artist).OrderByDescending(a => a.Title);
                        break;
                case "artist_asc":
                    albums = albums.Include(a => a.Artist).OrderBy(a => a.Artist.FirstName).ThenBy(a => a.Artist.LastName);
                    break;
                case "artist_desc":
                    albums = albums.Include(a => a.Artist).OrderByDescending(a => a.Artist.FirstName).ThenByDescending(a => a.Artist.LastName);
                    break;
                case "year_asc":
                    albums = albums.Include(a => a.Artist).OrderBy(a => a.Year);
                    break;
                case "year_desc":
                    albums = albums.Include(a => a.Artist).OrderByDescending(a => a.Year);
                    break;
                case "price_asc":
                    albums = albums.Include(a => a.Artist).OrderBy(a => a.Price);
                    break;
                case "price_desc":
                    albums = albums.Include(a => a.Artist).OrderByDescending(a => a.Price);
                    break;
                default:
                    albums = albums.Include(a => a.Artist).OrderBy(a => a.Title);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(albums.ToPagedList(pageNumber, pageSize));
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "ConcatNames");
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ArtistID,Year,Price")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "ConcatNames", album.ArtistID);
            return View(album);
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "ConcatNames", album.ArtistID);
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ArtistID,Year,Price")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "ConcatNames", album.ArtistID);
            return View(album);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
