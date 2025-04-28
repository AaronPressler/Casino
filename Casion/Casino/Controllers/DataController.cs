using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casino.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public JsonResult Index()
        {
            return Json(new Person() { Id = 3 }, JsonRequestBehavior.AllowGet);
        }
    }


    public class Person
    {
        public int Id { get; set; }
    }
}