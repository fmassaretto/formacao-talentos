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
            var model = new AdminCursoViewModel();

            using (var repoUser = new AdminCursoRepository())
            {
                var listaUsuario = repoUser.ListaUsuario();

                model.ListaUsuarios = (from x in listaUsuario
                                       select new SelectListItem
                                       {
                                           Text = x.Nome,
                                           Value = x.Id.ToString()
                                       });
            }

            using (var repoAssunto = new AdminCursoRepository())
            {
                var listaAssunto = repoAssunto.ListaAssunto();

                model.ListaAssunto = (from x in listaAssunto
                                      select new SelectListItem
                                      {
                                          Text = x.Nome,
                                          Value = x.Id.ToString()
                                      });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Criar(AssuntoCursoUsuario acu)
        {
            using (var repo = new AdminCursoRepository())
            {
                var inserido = repo.Inserir(acu);

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
            var model = new AdminCursoViewModel();

            using (var repoUser = new AdminCursoRepository())
            {
                var listaUsuario = repoUser.ListaUsuario();

                model.ListaUsuarios = (from x in listaUsuario select new SelectListItem {
                    Text = x.Nome,
                    Value = x.Id.ToString()
                });
            }

            using (var repoAssunto = new AdminCursoRepository())
            {
                var listaAssunto = repoAssunto.ListaAssunto();

                model.ListaAssunto = (from x in listaAssunto
                                       select new SelectListItem
                                       {
                                           Text = x.Nome,
                                           Value = x.Id.ToString()
                                       });
            }

            using (var repo = new CursoRepository())
            {
                model.Acu = repo.Obter(id);
            }
                return View(model);
        }

        [HttpPost]
        public ActionResult Editar(AssuntoCursoUsuario acu)
        {
            using (var repo = new AdminCursoRepository())
            {
                repo.Atualizar(acu);

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Deletar(int id)
        {
            using (var repo = new CursoRepository())
            {
                var curso = repo.Obter(id);

                return View(curso);
            }
        }

        [HttpPost]
        public ActionResult Deletar(AssuntoCursoUsuario acu)
        {
            using (var repo = new AdminCursoRepository())
            {
                repo.Excluir(acu);
            }
            return RedirectToAction("Index");
        }

    }
}