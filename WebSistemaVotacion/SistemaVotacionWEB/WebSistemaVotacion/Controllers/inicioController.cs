using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSistemaVotacion.Controllers
{
    public class inicioController : Controller
    {
        // GET: inicio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult error()
        {
            return View();
        }
    }
}