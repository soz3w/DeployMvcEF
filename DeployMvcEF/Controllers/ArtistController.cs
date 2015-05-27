using DeployMvcEF.Models;
using DeployMvcEF.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core;
using System.Transactions;

namespace DeployMvcEF.Controllers
{
    public class ArtistController : Controller
    {
        //MusicStoreContext db = new MusicStoreContext();

        //now with repository
        ArtistRepository repository = new ArtistRepository();

        // GET: Artist
        public ActionResult Index()
        {
            //return View(db.artists.ToList());
            return View(repository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid)
                return View(artist);

            //db.artists.Add(artist);
            //db.SaveChanges();

            //with repository
            repository.Add(artist);
            repository.SaveChanges();
            

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var artist = repository.Get(id);
            if (artist == null) return HttpNotFound();
            else return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            if (!ModelState.IsValid)
                return View(artist);

            //db.artists.Add(artist);
            //db.SaveChanges();

            //with repository
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    repository.Update(artist);
                    repository.SaveChanges();
                    scope.Complete();
                } 
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                ViewBag.Message = "Acces concurrentiel problème";
                return View(artist);
            }


            

        }
        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }

    }
}