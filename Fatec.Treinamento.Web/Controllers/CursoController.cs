using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using Fatec.Treinamento.Web.Models;
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
        
        public ActionResult Pesquisar(string txtPesquisaCurso)
        {
            IEnumerable<AssuntoCursoUsuario> listaPesquisa = new List<AssuntoCursoUsuario>();

            using (CursoRepository repo = new CursoRepository())
            {
                listaPesquisa = repo.ListarCursosPorNome(txtPesquisaCurso);
                foreach (var lista in listaPesquisa)
                {
                    //listaTodo.QtdUsuariosVotosCurso.Add(listaTodo.IdCurso);
                    lista.QtdUsuariosVotosCurso = repo.ObterQtdVotos(lista.IdCurso);
                    lista.TotalDuracaoCurso = repo.SomarDuracaoCurso(lista.IdCurso);
                }
            }
            
            return View(listaPesquisa);
        }

        public ActionResult Index()
        {
            IEnumerable<AssuntoCursoUsuario> listaTodos = new List<AssuntoCursoUsuario>();
            //IEnumerable<Capitulo> capitulos = new List<Capitulo>();

            using (CursoRepository repoTodos = new CursoRepository())
            {
                listaTodos = repoTodos.ListarTodosCursos();
                foreach (var listaTodo in listaTodos)
                {
                    //listaTodo.QtdUsuariosVotosCurso.Add(listaTodo.IdCurso);
                    listaTodo.QtdUsuariosVotosCurso = repoTodos.ObterQtdVotos(listaTodo.IdCurso);
                    listaTodo.TotalDuracaoCurso = repoTodos.SomarDuracaoCurso(listaTodo.IdCurso);
                }

            }
            
            return View(listaTodos);
        }

        public ActionResult Populares()
        {
            Console.WriteLine("Passou aqui1");
            IEnumerable<AssuntoCursoUsuario> listaPop = new List<AssuntoCursoUsuario>();
            using (CursoRepository repo = new CursoRepository())
            {
                listaPop = repo.ListarTodosCursos();
                foreach (var lista in listaPop)
                {
                    lista.QtdUsuariosVotosCurso = repo.ObterQtdVotos(lista.IdCurso);
                    lista.TotalDuracaoCurso = repo.SomarDuracaoCurso(lista.IdCurso);
                    Console.WriteLine("Passou aqui2");
                }

                var model = repo.ListarPopulares();
                return View(model);
            }
        }

        public ActionResult obter(int id)
        {
            using (var repo = new CursoRepository())
            {
                var curso = repo.Obter(id);

                return View(curso);
            }
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
        public ActionResult Editar(AssuntoCursoUsuario curso)
        {
            using (var repo = new CursoRepository())
            {
                curso = repo.Atualizar(curso);

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Detalhe(int? id)
        {
            //int id = (int)Url.RequestContext.RouteData.Values["Id"];
            AssuntoCursoUsuario listaDetalhe = new AssuntoCursoUsuario();

            using (CursoRepository repoDetalhe = new CursoRepository())
            {
                try
                {
                listaDetalhe = repoDetalhe.DetalheCurso(id);

                }
                catch (Exception)
                {

                    return RedirectToAction("Index", "Curso");
                    throw;
                }
            }

            //if (listaDetalhe.IdCurso == null)
            //{
            //}
            return View(listaDetalhe);
        }

        public ActionResult Assunto(int? id)
        {
            IEnumerable<AssuntoCursoUsuario> listaCursoAssunto = new List<AssuntoCursoUsuario>();

            using (AssuntoRepository repoCursoAssunto = new AssuntoRepository())
            {
                listaCursoAssunto = repoCursoAssunto.ListarCursosPorAssuntos(id);                
            }

            using (CursoRepository repoCurso = new CursoRepository())
            {
                foreach (var lista in listaCursoAssunto)
                {
                    //listaTodo.QtdUsuariosVotosCurso.Add(listaTodo.IdCurso);
                    lista.QtdUsuariosVotosCurso = repoCurso.ObterQtdVotos(lista.IdCurso);
                    lista.TotalDuracaoCurso = repoCurso.SomarDuracaoCurso(lista.IdCurso);
                }
            }

            if (listaCursoAssunto.Count() == 0)
            {
                return RedirectToAction("Index", "Curso");
            }

            var x = 0;
            foreach (var item in listaCursoAssunto)
            {
                /*  
                    Loop DoWhile que passa apenas uma vez para não 
                    declarar TempData["NomeAssunto"] varias vez 
                    sem necessidade
                */
                do
                {                    
                    TempData["NomeAssunto"] = item.NomeAssunto;
                    x++;
                } while (x == 0 );
                
            }
            return View(listaCursoAssunto);
        }



        [HttpGet]
        public ActionResult Assistir(int idCurso)
        {
            using (CursoRepository repo = new CursoRepository())
            {
                var curso = repo.DetalheCurso(idCurso);

                ViewBag.ShowHideVideo = "video-hide";

                return View(curso);
            }
        }



        [HttpGet]
        [Route("Curso/{IdCurso}/Assistir/Capitulo/{IdCapitulo}/Video/{IdVideo}", Name = "RotaAssistirVideo")]
        public ActionResult Assistir(int idCurso, int idCapitulo, int idVideo)
        {
            using (CursoRepository repo = new CursoRepository())
            {
                var curso = repo.DetalheCurso(idCurso);

                ViewBag.IdCapitulo = idCapitulo;
                ViewBag.IdVideo = idVideo;

                var capitulo = curso.Capitulos.FirstOrDefault(cap => cap.Id == idCapitulo);

                if (capitulo != null)
                {
                    var video = capitulo.Videos.FirstOrDefault(vid => vid.Id == idVideo);

                    if (video != null)
                    {
                        ViewBag.CodigoVideo = video.CodigoVideo;
                    }
                }

                ViewBag.ShowHideVideo = "video-show";

                return View(curso);
            }
        }



    }
}