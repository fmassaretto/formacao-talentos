using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Fatec.Treinamento.Web.Controllers
{
    public class TreinamentoController : Controller
    {
        
        [Authorize]
        public ActionResult Index()
        {

            int id = int.Parse(User.Identity.GetUserId());
            
            return View();
        }
    }
}