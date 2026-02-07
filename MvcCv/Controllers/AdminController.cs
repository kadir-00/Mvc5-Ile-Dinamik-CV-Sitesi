using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        GenericReporsitory<TblAdmin> repo = new GenericReporsitory<TblAdmin>();

        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdminEkle(TblAdmin adm)
        {
            repo.TAdd(adm);
            return RedirectToAction("Index");
        }


        public ActionResult AdminSil(int id)
        {
            TblAdmin a = repo.Find(x => x.ID == id);
            repo.TDelete(a);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult AdminGetir(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
           
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}