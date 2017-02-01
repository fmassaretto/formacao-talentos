using Fatec.Treinamento.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class AdminCursosController : Controller
    {
        // GET: AdminCursos
        [HttpGet]
        public ActionResult Index()
        {
            using (var repo = new CursoRepository())
            {
                var lista = repo.ListarTodosCursos();
                return View(lista);
            }
        }

        [HttpGet]
        public ActionResult Obter(int id)
        {
            using (var repo = new CursoRepository())
            {
                var lista = repo.Obter(id);
                return View(lista);
            }          
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

       
    }
}