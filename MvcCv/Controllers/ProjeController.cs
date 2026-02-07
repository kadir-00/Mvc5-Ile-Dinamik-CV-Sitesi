using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ProjeController : Controller
    {
        // GET: Proje
        GenericReporsitory<TblProjelerim> repo = new GenericReporsitory<TblProjelerim>();

        public ActionResult Index()
        {
            var project = repo.List();
            return View(project);
        }

        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjeEkle(TblProjelerim projects)
        {
            if (!ModelState.IsValid)
            {
                return View("ProjeEkle");
            }
            repo.TAdd(projects);
            return RedirectToAction("Index");
        }

        public ActionResult ProjeSil(int id)
        {
            TblProjelerim pr = repo.Find(x => x.ID == id);
            repo.TDelete(pr);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProjeGetir(int id)
        {
            TblProjelerim some = repo.Find(x => x.ID == id);
            return View(some);
        }


        [HttpPost]
        public ActionResult ProjeGetir(TblProjelerim prj)
        {
            if (!ModelState.IsValid)
            {
                return View("ProjeGetir");
            }
            TblProjelerim projects = repo.Find(x => x.ID == prj.ID);
            projects.ProjeAd = prj.ProjeAd;
            projects.ProjeLink = prj.ProjeLink;
            projects.ProjeAciklama = prj.ProjeAciklama;

            repo.TUpdate(projects);
            return RedirectToAction("Index");
        }
    }
}