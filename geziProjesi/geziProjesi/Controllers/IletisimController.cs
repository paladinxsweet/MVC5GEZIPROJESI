using geziProjesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace geziProjesi.Controllers
{
    public class IletisimController : Controller
    {
        Context c = new Context();
        // GET: Iletisim
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hakkimizda()
        {
            var hkmz = c.Hakkimizdas.ToList();
            return View("Hakkimizda");

        }
       
        
    }
}