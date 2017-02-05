using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class PainelController : Controller
    {
        // GET: Painel
        public ActionResult Index()
        {
            IEnumerable<AssuntoCursoUsuario> listaTodos = new List<AssuntoCursoUsuario>();

            using (CursoRepository repoTodos = new CursoRepository())
            {
                listaTodos = repoTodos.ListarTodosCursos();
            }
            return View(listaTodos);
        }
    }
}