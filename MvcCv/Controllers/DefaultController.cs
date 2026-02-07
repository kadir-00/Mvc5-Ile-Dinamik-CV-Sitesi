using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvEntities db = new DbCvEntities();   
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.Where(x => x.Status == true).ToList();  //status değeri true olanları uı tarafında göstercek yani aktif olanlar
            return View(degerler);
        }
        public PartialViewResult Deneyim() 
        { 
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x => x.Status == true).ToList(); //status değeri true olanları uı tarafında göstercek yani aktif olanlar
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Egitim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenek()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobi()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifika()
        {
            var sertifikalar = db.TblSertifikalarim.ToList();
            return PartialView(sertifikalar);
        }

        public PartialViewResult Proje()
        {
            var projeler = db.TblProjelerim.ToList();
            return PartialView(projeler);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Iletisim(Tbliletisim iletisim)
        {
            iletisim.Tarih= DateTime.Parse(DateTime.Now.ToShortDateString());
             db.Tbliletisim.Add(iletisim);
            db.SaveChanges();
            return PartialView();
        }
    }
}