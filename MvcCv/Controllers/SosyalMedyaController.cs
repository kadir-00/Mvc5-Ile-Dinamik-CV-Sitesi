using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericReporsitory<TblSosyalMedya> repo = new GenericReporsitory<TblSosyalMedya>();

        public ActionResult Index()
        {
            var socialmedia = repo.List();
            return View(socialmedia);
        }

        [HttpGet]
        public ActionResult SosyalMedyaEkle()
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
        public ActionResult SosyalMedyaEkle(TblSosyalMedya socialmedias)
        {
            if (!ModelState.IsValid)
            {
                return View("SosyalMedyaEkle");
            }
            repo.TAdd(socialmedias);
            return RedirectToAction("Index");
        }

        public ActionResult SosyalMedyaSil(int id)
        {
            TblSosyalMedya sm = repo.Find(x => x.ID == id);
            repo.TDelete(sm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            TblSosyalMedya some = repo.Find(x => x.ID == id);
            return View(some);
        }


        [HttpPost]
        public ActionResult SosyalMedyaGetir(TblSosyalMedya somes)
        {
            if (!ModelState.IsValid)
            {
                return View("SosyalMedyaGetir");
            }
            TblSosyalMedya socialmedias = repo.Find(x => x.ID == somes.ID);
            socialmedias.SosyalMedyaLink = somes.SosyalMedyaLink;
            socialmedias.Icon = somes.Icon;
            socialmedias.Status = true;
           
            repo.TUpdate(socialmedias);
            return RedirectToAction("Index");
        }
    }
}