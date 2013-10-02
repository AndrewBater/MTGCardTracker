using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MtgTracker.Controllers
{
    public class CardController : Controller
    {
        //
        // GET: /Card/

        public ActionResult Index(string name)
        {
            return View();
        }

    }
}
