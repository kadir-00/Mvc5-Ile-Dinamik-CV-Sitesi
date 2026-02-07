using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericReporsitory<TblIletisimBilgi> repo = new GenericReporsitory<TblIletisimBilgi>();

        public ActionResult Index()
        {
            var contact = repo.List();
            return View(contact);
        }

        [HttpGet]
        public ActionResult IletisimEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult IletisimEkle(TblIletisimBilgi contacts)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaEkle");
            }
            repo.TAdd(contacts);
            return RedirectToAction("Index");
        }

        public ActionResult IletisimSil(int id)
        {
            TblIletisimBilgi il = repo.Find(x => x.ID == id);
            repo.TDelete(il);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult IletisimGetir(int id)
        {
            TblIletisimBilgi con = repo.Find(x => x.ID == id);
            return View(con);
        }

        [HttpPost]
        public ActionResult IletisimGetir(TblIletisimBilgi iletisim)
        {
            if (!ModelState.IsValid)
            {
                return View("IletisimGetir");
            }
            TblIletisimBilgi contacts = repo.Find(x => x.ID == iletisim.ID);
            contacts.AdSoyad = iletisim.AdSoyad;
            contacts.Mail = iletisim.Mail;
            contacts.Telefon = iletisim.Telefon;
            contacts.Konum = iletisim.Konum;
   

            repo.TUpdate(contacts);
            return RedirectToAction("Index");
        }

    }
}