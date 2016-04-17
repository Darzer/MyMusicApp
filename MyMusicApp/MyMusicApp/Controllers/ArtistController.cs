using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using PagedList;
using System.Web;
using System.Web.Mvc;
using MyMusicApp.DAL;
using MyMusicApp.Models;

namespace MyMusicApp.Controllers
{
    public class ArtistController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Artist
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSort = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewBag.LastNameSort = sortOrder == "last_name_asc" ? "last_name_desc" : "last_name_asc";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var artists = from a in db.Artists select a;

            // If searchString isn't empty this statement will compare it to Artist.FirstName & .LastName after capitalising each of them.
            // If it matches any entries in the Artist table they will be assigned to 'artists'.
            if (!String.IsNullOrEmpty(searchString))
            {
                artists = artists.Where(a => a.FirstName.ToUpper().Contains(searchString.ToUpper())
                                            ||
                a.LastName.ToUpper().Contains(searchString.ToUpper())
                                            ||
                String.Concat(a.FirstName + " " + a.LastName).ToUpper().Contains(searchString.ToUpper()));
            }

            switch(sortOrder)
            {
                case "first_name_desc":
                    artists = artists.OrderByDescending(a => a.FirstName);
                    break;
                case "last_name_asc":
                    artists = artists.OrderBy(a => a.LastName);
                    break;
                case "last_name_desc":
                    artists = artists.OrderByDescending(a => a.LastName);
                    break;
                default:
                    artists = artists.OrderBy(a => a.FirstName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(artists.ToPagedList(pageNumber, pageSize));
        }

        // GET: Artist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
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
