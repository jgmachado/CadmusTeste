using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cadmus.Entities.Collections;
using Cadmus.Business;
using Cadmus.Entities;

namespace Cadmus.Controllers
{
    public class EstadosController : Controller
    {
        //
        // GET: /Estados/

        public ActionResult Index()
        {
            var model = EstadosPlatform.Instance.GetEstados();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Estado estado)
        {
            int resp = EstadosPlatform.Instance.SaveEstado(estado);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = EstadosPlatform.Instance.GetEstado(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(Estado estado)
        {
            int resp = EstadosPlatform.Instance.UpdateEstado(estado);
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            var model = EstadosPlatform.Instance.GetEstado(id);
            EstadosPlatform.Instance.DeleteEstado(model);
            return RedirectToAction("Index");
        }
    }
}
