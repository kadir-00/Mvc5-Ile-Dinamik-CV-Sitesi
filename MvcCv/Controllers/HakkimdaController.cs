using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{

    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericReporsitory<TblHakkimda> repo = new GenericReporsitory<TblHakkimda>();

        public ActionResult Index()
        {
            var myabout = repo.List();
            return View(myabout);
        }

        [HttpGet]
        public ActionResult HakkimdaEkle()
        {
            return View();
        }

        public ActionResult MakeActive(int id)
        {
            var item = repo.Find(x => x.ID == id);
            if (item != null)
            {
                item.Status = true;
                repo.TUpdate(item);
                return RedirectToAction("Index");
            }
            else
            {
                // Belirli bir ID'ye sahip öğe bulunamadı
                return HttpNotFound();
            }
        }

        public ActionResult MakePassive(int id)
        {
            var item = repo.Find(x => x.ID == id);
            if (item != null)
            {
                item.Status = false;
                repo.TUpdate(item);
                return RedirectToAction("Index");
            }
            else
            {
                // Belirli bir ID'ye sahip öğe bulunamadı
                return HttpNotFound();
            }
        }


        [HttpPost]
        public ActionResult HakkimdaEkle(TblHakkimda about)
        {
            if (!ModelState.IsValid)
            {
                return View("HakkimdaEkle");
            }
            repo.TAdd(about);
            return RedirectToAction("Index");
        }


        public ActionResult HakkimdaSil(int id)
        {
            TblHakkimda h = repo.Find(x => x.ID == id);
            repo.TDelete(h);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HakkimdaGetir(int id)
        {
            TblHakkimda ab = repo.Find(x => x.ID == id);
            return View(ab);
        }

        [HttpPost]
        public ActionResult HakkimdaGetir(TblHakkimda about)
        {
            if (!ModelState.IsValid)
            {
                return View("HakkimdaGetir");
            }
            TblHakkimda abouts = repo.Find(x => x.ID == about.ID);
            abouts.Ad = about.Ad;
            abouts.Soyad = about.Soyad;
            abouts.Adres = about.Adres;
            abouts.Telefon = about.Telefon;
            abouts.Mail = about.Mail;
            abouts.Aciklama = about.Aciklama;
            abouts.Resim = about.Resim;
            abouts.Status = true;

            repo.TUpdate(abouts);
            return RedirectToAction("Index");
        }

    }
}