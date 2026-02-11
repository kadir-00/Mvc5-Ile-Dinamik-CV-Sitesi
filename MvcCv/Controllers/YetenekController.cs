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
        GenericReporsitory<TblYetenekler> repo = new GenericReporsitory<TblYetenekler>();
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
        public ActionResult YetenekEkle(TblYetenekler skill)
        {
            repo.TAdd(skill);
            return RedirectToAction("Index");
        }


        public ActionResult YetenekSil(int id)
        {
            TblYetenekler y = repo.Find(x => x.ID == id);
            repo.TDelete(y);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            TblYetenekler s = repo.Find(x => x.ID == id);
            return View(s);
        }

        [HttpPost]
        public ActionResult YetenekGetir(TblYetenekler s)
        {
            TblYetenekler y = repo.Find(x => x.ID == s.ID);
            y.Yetenek = s.Yetenek;
            y.Oran = s.Oran;
           
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}