using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model.DTO;
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

        [HttpGet]
        public ActionResult Editar(int id)
        {
            using (var repo = new CursoRepository())
            {
                var curso = repo.Obter(id);

                return View(curso);
            }
        }

        [HttpPost]
        public ActionResult Editar(AssuntoCursoUsuario acu)
        {
            using (var repo = new CursoRepository())
            {
                var curso = repo.Atualizar(acu);

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult ListarUsuarios(int id)
        {
            var model = new AssuntoCursoUsuario();

            using (var repo = new CursoRepository())
            {
                var curso = repo.Obter(id);
            }

            

            using (var repo = new UsuarioRepository())
            {
                model.ListaUsuarios = repo.Listar();


                
            }

            return View(model);
        }

    }
}