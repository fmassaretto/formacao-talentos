using Fatec.Treinamento.Data;
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
                    lista.QtdUsuariosVotosCurso = repo.ObterQtdVotos(lista.IdCurso);
                    lista.TotalDuracaoCurso = repo.SomarDuracaoCurso(lista.IdCurso);
                }
            }
            
            return View(listaPesquisa);
        }

        public ActionResult Index()
        {
            IEnumerable<AssuntoCursoUsuario> listaTodos = new List<AssuntoCursoUsuario>();

            using (CursoRepository repoTodos = new CursoRepository())
            {
                listaTodos = repoTodos.ListarTodosCursos();
                foreach (var listaTodo in listaTodos)
                {
                    listaTodo.QtdUsuariosVotosCurso = repoTodos.ObterQtdVotos(listaTodo.IdCurso);
                    listaTodo.TotalDuracaoCurso = repoTodos.SomarDuracaoCurso(listaTodo.IdCurso);
                }
            }            
            return View(listaTodos);
        }

        [HttpGet]
        public ActionResult Populares()
        {

            IEnumerable<AssuntoCursoUsuario> listaPop = new List<AssuntoCursoUsuario>();
            using (CursoRepository repo = new CursoRepository())
            {
                listaPop = repo.ListarTodosCursos();
                foreach (var lista in listaPop)
                {
                    lista.QtdUsuariosVotosCurso = repo.ObterQtdVotos(lista.IdCurso);
                    lista.TotalDuracaoCurso = repo.SomarDuracaoCurso(lista.IdCurso);
                }

                listaPop = repo.ListarPopulares();

                return View(listaPop);
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
            AssuntoCursoUsuario listaDetalhe = new AssuntoCursoUsuario();

            using (CursoRepository repoDetalhe = new CursoRepository())
            {
                try
                {
                    listaDetalhe = repoDetalhe.DetalheCurso(id);
                    listaDetalhe.QtdUsuariosVotosCurso = repoDetalhe.ObterQtdVotos(id);
                    listaDetalhe.TotalDuracaoCurso = repoDetalhe.SomarDuracaoCurso(id);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Curso");
                    throw;
                }
            }
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
            int idUsuario = 0;
            using (UsuarioRepository usuario = new UsuarioRepository())
            {
                var listaUsuario = usuario.ListarPorNome(User.Identity.Name);

                foreach (var item in listaUsuario)
                {
                    idUsuario = item.Id;
                }
            } 

            using (TreinamentoRepository repoTrei = new TreinamentoRepository())
            {
                var treinamento = repoTrei.ObterTreinamento(idUsuario, idCurso);
                if (treinamento != null)
                {
                        repoTrei.AtualizarUltimoAcessoTreinamento(treinamento.Id);
                }else
                {
                        repoTrei.ComecarTreinamento(idUsuario, idCurso);
                }
            }

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

        [HttpGet]
        public ActionResult Prova(int id)
        {
            int idUsuario = 0;

            using (UsuarioRepository usuario = new UsuarioRepository())
            {
                var listaUsuario = usuario.ListarPorNome(User.Identity.Name);

                foreach (var item in listaUsuario)
                {
                    idUsuario = item.Id;
                }
            }

            using (TreinamentoRepository repoTrei = new TreinamentoRepository())
            {
                var treinamento = repoTrei.ObterTreinamento(idUsuario, id);
                if (treinamento.DataConclusao == null)
                {
                    if (treinamento != null)
                    {
                        repoTrei.AtualizarDataConclusaoTreinamento(treinamento.Id);
                    }
                }
            }
            
            using (var repo = new CursoRepository())
            {
                var curso = repo.Obter(id);
                curso.IdUsuario = idUsuario;
                return View(curso);
            }
        }

        [HttpPost]
        public ActionResult Prova(AssuntoCursoUsuario acu)
        {
            var idCurso = acu.IdCurso;
            var idUsuario = acu.IdUsuario;
            var nota = acu.SelectedNota;
            int notaInt = Int32.Parse(nota);

            using (CursoRepository repo = new CursoRepository())
            {
                repo.InserirNota(idCurso, idUsuario, notaInt);
            }

            using (TreinamentoRepository repoTrei = new TreinamentoRepository())
            {
                var treinamento = repoTrei.ObterTreinamento(idUsuario, idCurso);
                if (treinamento.DataConclusao.ToString() == "01/01/0001 00:00:00")
                {
                    if (treinamento != null)
                    {
                        repoTrei.AtualizarDataConclusaoTreinamento(treinamento.Id);
                    }
                }
            }
            return RedirectToAction("Index", "Curso");           
        }
    }
}