using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class VoltarController : Controller
    {
        //// GET: Voltar
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult ActionDeVoltar(string returnUrl)
        {
            if (returnUrl != "")
                return Redirect(returnUrl);

            return null;
        }
    }
}