using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using geziProjesi.Models.Siniflar;
namespace geziProjesi.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        // GET: Admin

       [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();

        }
     
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
       
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
      
        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);

            return View("BlogGetir",b);


        }
      
        public ActionResult BlogGuncelle(Blog b)
        {

            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
       
        public ActionResult YorumListesi()
        {
            var yorumlar = c.yorumlars.ToList();
            return View(yorumlar);

        }
    
        public ActionResult YorumSil(int id)
        {
            var b = c.yorumlars.Find(id);
            c.yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
     
        public ActionResult YorumGetir(int id)
        {
            var yr = c.yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
       
        public ActionResult YorumGuncelle(Yorumlar y)
        {

            var yrm = c.yorumlars.Find(y.Id);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}