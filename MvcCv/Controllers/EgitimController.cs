using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim

        GenericReporsitory<TblEgitimlerim> repo = new GenericReporsitory<TblEgitimlerim>();
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim education)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(education);
            return RedirectToAction("Index");
        }


        public ActionResult EgitimSil(int id)
        {
            TblEgitimlerim e = repo.Find(x => x.ID == id);
            repo.TDelete(e);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TblEgitimlerim eg = repo.Find(x => x.ID == id);
            return View(eg);
        }

        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim ed)
        {
            TblEgitimlerim educations = repo.Find(x => x.ID == ed.ID);
            educations.Baslik = ed.Baslik;
            educations.AltBaslik1 = ed.AltBaslik1;
            educations.AltBaslik2 = ed.AltBaslik2;
            educations.GNO = ed.GNO;
            educations.Tarih = ed.Tarih;

            repo.TUpdate(educations);
            return RedirectToAction("Index");
        }

    }
}