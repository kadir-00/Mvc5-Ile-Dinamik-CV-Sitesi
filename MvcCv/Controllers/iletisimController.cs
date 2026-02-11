using MvcCv.Models.Siniflar;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: iletisim
        GenericReporsitory<Iletisim> repo = new GenericReporsitory<Iletisim>();

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
        public ActionResult IletisimEkle(Iletisim contacts)
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
            Iletisim il = repo.Find(x => x.ID == id);
            repo.TDelete(il);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult IletisimGetir(int id)
        {
            Iletisim con = repo.Find(x => x.ID == id);
            return View(con);
        }

        [HttpPost]
        public ActionResult IletisimGetir(Iletisim iletisim)
        {
            if (!ModelState.IsValid)
            {
                return View("IletisimGetir");
            }
            Iletisim contacts = repo.Find(x => x.ID == iletisim.ID);
            contacts.AdSoyad = iletisim.AdSoyad;
            contacts.Mail = iletisim.Mail;
            //contacts.Telefon = iletisim.Telefon; // Iletisim entity properties might differ, checking definition
            //contacts.Konum = iletisim.Konum;


            repo.TUpdate(contacts);
            return RedirectToAction("Index");
        }

    }
}