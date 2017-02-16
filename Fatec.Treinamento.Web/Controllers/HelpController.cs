using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class HelpController : Controller
    {
        // GET: Help
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Trilhas()
        {
            return View();
        }

        public ActionResult Autores()
        {
            return View();
        }

        public ActionResult Pontos()
        {
            return View();
        }


    }
}