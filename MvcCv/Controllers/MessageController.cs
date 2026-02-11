using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        GenericReporsitory<TblIletisim> repo = new GenericReporsitory<TblIletisim>();

        public ActionResult Index()
        {
            var message = repo.List();
            return View(message);
        }

        public ActionResult MesajSil(int id)
        {
            TblIletisim iletisim = repo.Find(x => x.ID == id);
            repo.TDelete(iletisim);
            return RedirectToAction("Index");
        }
    }
}