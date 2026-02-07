using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericReporsitory<TblYeteneklerim> repo = new GenericReporsitory<TblYeteneklerim>();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YetenekEkle(TblYeteneklerim skill)
        {
            repo.TAdd(skill);
            return RedirectToAction("Index");
        }


        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim y = repo.Find(x => x.ID == id);
            repo.TDelete(y);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            TblYeteneklerim s = repo.Find(x => x.ID == id);
            return View(s);
        }

        [HttpPost]
        public ActionResult YetenekGetir(TblYeteneklerim s)
        {
            TblYeteneklerim y = repo.Find(x => x.ID == s.ID);
            y.Yetenek = s.Yetenek;
            y.Oran = s.Oran;
           
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}