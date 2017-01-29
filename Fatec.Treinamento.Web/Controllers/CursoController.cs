using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        [HttpPost]
        public ActionResult Pesquisar(string txtPesquisaCurso)
        {
            IEnumerable<DetalhesCurso> lista = new List<DetalhesCurso>();

            using (CursoRepository repo = new CursoRepository())
            {
                lista = repo.ListarCursosPorNome(txtPesquisaCurso);
            }

            return View(lista);
        }

        public ActionResult Index()
        {
            IEnumerable<DetalhesCurso> listaTodos = new List<DetalhesCurso>();

            using (CursoRepository repoTodos = new CursoRepository())
            {
                listaTodos = repoTodos.ListarTodosCursos();
            }
            return View(listaTodos);
        }

        //public ActionResult Detalhe()
        //{
        //    return View();
        //}

        //[HttpPost]
        public ActionResult Detalhe(int id)
        {
            //int id = (int)Url.RequestContext.RouteData.Values["Id"];
            IEnumerable<Detalhe> listaDetalhe = new List<Detalhe>();

            using (CursoRepository repoDetalhe = new CursoRepository())
            {
                listaDetalhe = repoDetalhe.DetalheCurso(id);
            }
            return View(listaDetalhe);
        }
    }
}