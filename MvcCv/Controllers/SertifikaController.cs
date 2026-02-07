using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericReporsitory<TblSertifikalarim> repo = new GenericReporsitory<TblSertifikalarim>();

        public ActionResult Index()
        {
            var certificate = repo.List();
            return View(certificate);
        }


        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim certificate)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaEkle");
            }
            repo.TAdd(certificate);
            return RedirectToAction("Index");
        }


        public ActionResult SertifikaSil(int id)
        {
            TblSertifikalarim c = repo.Find(x => x.ID == id);
            repo.TDelete(c);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            TblSertifikalarim ce = repo.Find(x => x.ID == id);
            return View(ce);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim se)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaGetir");
            }
            TblSertifikalarim certificates = repo.Find(x => x.ID == se.ID);
            certificates.Aciklama = se.Aciklama;
            certificates.KursAd = se.KursAd;
            certificates.Teknolojiler = se.Teknolojiler;
            certificates.Tarih = se.Tarih;
            certificates.SertifikaUrl = se.SertifikaUrl;

            repo.TUpdate(certificates);
            return RedirectToAction("Index");
        }

    }
}