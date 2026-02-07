using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericReporsitory<TblHobilerim> repo = new GenericReporsitory<TblHobilerim>();

        public ActionResult Index()
        {
            var hobbies = repo.List();
            return View(hobbies);
        }

        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult HobiEkle(TblHobilerim hobbie)
        {
            if (!ModelState.IsValid)
            {
                return View("HobiEkle");
            }
            repo.TAdd(hobbie);
            return RedirectToAction("Index");
        }

        public ActionResult HobiSil(int id)
        {
            TblHobilerim h = repo.Find(x => x.ID == id);
            repo.TDelete(h);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult HobiGetir(int id)
        {
            TblHobilerim ho = repo.Find(x => x.ID == id);
            return View(ho);
        }

        [HttpPost]
        public ActionResult HobiGetir(TblHobilerim hob)
        {
            if (!ModelState.IsValid)
            {
                return View("HobiGetir");
            }
            TblHobilerim hobbies = repo.Find(x => x.ID == hob.ID);
            hobbies.Aciklama1 = hob.Aciklama1;
            hobbies.Aciklama2 = hob.Aciklama2;
            
            repo.TUpdate(hobbies);
            return RedirectToAction("Index");
        }

    }
}