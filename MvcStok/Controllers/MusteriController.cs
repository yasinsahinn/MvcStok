using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db = new MvcDbStokEntities1 ();
        public ActionResult Index(string p)
        {
            var degerler = from i in db.TBLMUSTERİLER select i;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m=>m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniMusteri() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERİLER p1)
        { 
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }

            db.TBLMUSTERİLER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteriler = db.TBLMUSTERİLER.Find(id);
            db.TBLMUSTERİLER.Remove(musteriler);
            db.SaveChanges ();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERİLER.Find (id);
            return View("MusteriGetir",musteri);
        }
        public ActionResult Guncelle(TBLMUSTERİLER p1)
        {
            var musteri = db.TBLMUSTERİLER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}