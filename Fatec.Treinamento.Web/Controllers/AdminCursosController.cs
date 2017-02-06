using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model.DTO;
using Fatec.Treinamento.Web.Models;
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
            var model = new CursoAssuntoUsuarioViewModel();

            using (var repo = new UsuarioRepository())
            {
                var lista = repo.Listar();
                foreach (var user in lista)
                {
                    var item = new SelectListItem
                    {
                        Text = user.Nome,
                        Value = user.Id.ToString()
                    };
                    model.ListaUsuarios.Add(item);
                }
            }

            using (var repo = new AssuntoRepository())
            {
                var lista = repo.Listar();
                foreach (var assunto in lista)
                {
                    var item = new SelectListItem
                    {
                        Text = assunto.NomeAssunto,
                        Value = assunto.IdAssunto.ToString()
                    };
                    model.ListaAssuntos.Add(item);
                }
            }


            return View(model);


        }

        [HttpPost]
        public ActionResult Criar(CursoAssuntoUsuarioViewModel acu)
        {
            using (var repo = new CursoRepository())
            {
                var inserido = repo.Inserir(acu.Curso);

                if (inserido.IdCurso == 0)
                {
                    ModelState.AddModelError("", "Erro");
                }
            }
            return RedirectToAction("Index");
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

        //[HttpGet]
        //public ActionResult ListarUsuariosAssuntos()
        //{
            
        //}

    }
}