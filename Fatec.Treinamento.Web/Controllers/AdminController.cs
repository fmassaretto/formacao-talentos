using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        /* Controller para redirecionar para respectiva pagina quando clica em um 
        link na pagina painel do administrador */
        public ActionResult Redirecionador(string toPage)
        {
            switch (toPage)
            {
                case "Usuarios":
                    return RedirectToAction("Index", "AdminUsuarios");
                case "Cursos":
                    return RedirectToAction("Index", "AdminCursos");
                case "Assuntos":
                    return RedirectToAction("Assunto", "Admin");
                case "Trilhas":
                    return RedirectToAction("Index", "AdminTrilhas");
                case "Viseos":
                    return RedirectToAction("Video", "Admin");
                default:
                    return RedirectToAction("Index", "Painel");
            }
            
        }
    }
}