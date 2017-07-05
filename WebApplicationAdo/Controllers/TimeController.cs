using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationAdo.Models;
using WebApplicationAdo.Repositorio;

namespace WebApplicationAdo.Controllers
{
    public class TimeController : Controller
    {
        private  TimeRepositorio _repositorio;
        
        public ActionResult ObterTimes()
        {
            _repositorio = new TimeRepositorio();
            var times = _repositorio.ObterTimes();
            ModelState.Clear();
            return View(times);
        }

        [HttpGet]
        public ActionResult IncluirTime()
        {
            return View(new Times());
        }

        [HttpPost]
        public ActionResult IncluirTime(Times timeObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new TimeRepositorio();

                    if (_repositorio.AdicionarTime(timeObj))
                    {
                        ViewBag.Mensagem = "Time cadastrado com sucesso";
                    }
                }

                return View();
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }
        }

        [HttpGet]
        public ActionResult EditarTime(int id)
        {
            _repositorio = new TimeRepositorio();
            var time = _repositorio.ObterTimes().Find(t => t.TimeId == id); //Não é uma boa prática, crie uma proc que retorne somente 1 time
            return View(time);
        }

        [HttpPost]
        public ActionResult EditarTime(Times timeObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new TimeRepositorio();
                    _repositorio.AtualizarTime(timeObj);
                }

                return RedirectToAction("ObterTimes");
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }
        }
        
        public ActionResult ExcluirTime(int id)
        {
            try
            {
                _repositorio = new TimeRepositorio();
                if (_repositorio.ExcluirTime(id))
                {
                    ViewBag.Mensagem = "Time excluído com sucesso";
                }

                return RedirectToAction("ObterTimes");

            }
            catch (Exception)
            {
                return View("ObterTimes");
            }
        }
    }
}