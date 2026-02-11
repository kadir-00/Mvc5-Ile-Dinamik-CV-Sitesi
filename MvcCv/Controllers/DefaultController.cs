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

        DbCV2Entities db = new DbCV2Entities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();  //status değeri true olanları uı tarafında 
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        //public PartialViewResult SosyalMedya()
        //{
        //    var sosyalmedya = db.TblSosyalMedya.Where(x => x.Status == true).ToList(); //status değeri true olanları uı tarafında göstercek yani aktif olanlar
        //    return PartialView(sosyalmedya);
        //}
        public PartialViewResult Egitim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenek()
        {
            var yetenekler = db.TblYetenekler.ToList();
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
            var projeler = db.TblYetenekler.ToList();
            return PartialView(projeler);
        }

        //[HttpGet]
        //public PartialViewResult Iletisim()
        //{
        //    return PartialView();
        //}

        //[HttpPost]
        //public PartialViewResult Iletisim(TblIletisim iletisim, DateTime dateTime)
        //{
        //    iletisim.Tarih = dateTime.Parse(DateTime.Now.ToShortDateString());
        //    db.TblIletisim.Add(iletisim);
        //    db.SaveChanges();
        //    return PartialView();
        //}
    }
}