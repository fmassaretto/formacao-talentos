using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model.DTO;
using Fatec.Treinamento.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            //Salvo os usuarios a guardo na variavel listaUsuario
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

            //Salvo os assuntos a guardo na variavel listaAssunto
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
        public ActionResult Criar(AdminCursoViewModel model)
        {
            using (var repo = new AdminCursoRepository())
            {
                model.Acu.Img = model.Img.FileName.ToString();
                var inserido = repo.Inserir(model.Acu);


                if (inserido.IdCurso == 0)
                {
                    ModelState.AddModelError("", "Erro");
                }


                if (Request.Files.Count > 0)
                {
                    //var file = Request.Files[0];
                    if (ModelState.IsValid)
                    {
                       //model.Acu.Img = model.Img.FileName.ToString();
                        var filename = Path.GetFileName(model.Img.FileName);
                        var shortPath = "/Content/Img/Cursos/" + model.Acu.Nome;
                        var path = Path.Combine(Server.MapPath(shortPath), filename);

                        //Verifica se não existe o diretorio então cria o diretorio
                        if (!Directory.Exists(Server.MapPath(shortPath)))
                        {
                            var directory = Directory.CreateDirectory(Server.MapPath(shortPath));
                        }

                        model.Img.SaveAs(path);
                    }               
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
                model.Acu = repoUser.Obter(id);
                var listaUsuario = repoUser.ListaUsuario();
                model.Acu.UsuarioSelecionado = model.Acu.IdAutor;

                model.ListaUsuarios = (from x in listaUsuario select new SelectListItem {
                    Text = x.Nome,
                    Value = x.Id.ToString(),
                    Selected = model.Acu.NomeAutor == x.Nome
                });
            }


            using (var repoAssunto = new AdminCursoRepository())
            {
                model.Acu.AssuntoSelecionado = model.Acu.IdAssunto;

                var listaAssunto = repoAssunto.ListaAssunto();

                model.ListaAssunto = (from x in listaAssunto
                                       select new SelectListItem
                                       {
                                           Text = x.Nome,
                                           Value = x.Id.ToString(),
                                           Selected = model.Acu.NomeAssunto == x.Nome
                                       });
            }

                return View(model);
        }

        [HttpPost]
        public ActionResult Editar(AdminCursoViewModel model)
        {
            using (var repo = new AdminCursoRepository())
            {
                var fileNameOld = repo.Obter(model.Acu.IdCurso);

                var shortPathOld = "/Content/Img/Cursos/" + fileNameOld.Nome;


                model.Acu.Img = model.Img.FileName.ToString();
                repo.Atualizar(model.Acu);

                if (Request.Files.Count > 0)
                {
                    //var file = Request.Files[0];
                    if (ModelState.IsValid)
                    {
                        var filename = Path.GetFileName(model.Img.FileName);
                        var shortPath = "/Content/Img/Cursos/" + model.Acu.Nome;
                        var path = Path.Combine(Server.MapPath(shortPath), filename);

                        if (Directory.Exists(Server.MapPath(shortPathOld)))
                        {
                            if(shortPathOld != shortPath)
                                Directory.Move(Server.MapPath(shortPathOld), Server.MapPath(shortPath));
                        }else
                        {
                            Directory.CreateDirectory(Server.MapPath(shortPath));
                        }

                        model.Img.SaveAs(path);
                        //Verifica se não existe o diretorio então cria o diretorio
                       

                    }
                }
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