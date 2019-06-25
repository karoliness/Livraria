using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria.Controllers
{
    public class ItensController : Controller
    {
        // GET: Itens
        public ActionResult Index()
        {
            return View();
        }
    }
}