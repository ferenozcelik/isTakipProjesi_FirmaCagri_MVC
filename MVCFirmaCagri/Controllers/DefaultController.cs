using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFirmaCagri.Models.Entity;

namespace MVCFirmaCagri.Controllers
{
    public class DefaultController : Controller
    {

        DbisTakipEntities db = new DbisTakipEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AktifCagrilar()
        {
            var aktifCagrilar = db.TblCagrilar.Where(x => x.Durum == true && x.CagriFirma == 4).ToList();
            return View(aktifCagrilar);
        }

        public ActionResult PasifCagrilar()
        {
            var pasifCagrilar = db.TblCagrilar.Where(x => x.Durum == false && x.CagriFirma == 4).ToList();
            return View(pasifCagrilar);
        }

        [HttpGet]
        public ActionResult YeniCagri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCagri(TblCagrilar p)
        {
            p.Durum = true;
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CagriFirma = 4;
            db.TblCagrilar.Add(p);
            db.SaveChanges();
            return RedirectToAction("AktifCagrilar");
        }


        public ActionResult CagriDetay(int id)
        {
            var cagri = db.TblCagriDetay.Where(x => x.Cagri == id).ToList();
            return View(cagri);
        }
        
    }
}