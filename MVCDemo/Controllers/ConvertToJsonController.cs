using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ConvertToJsonController : Controller
    {
        // GET: JSON
        public ActionResult ConvertToJson(Type EnumType)
        {
             var jsonModel = string.Format(EnumType.Name) ;
             return Json(jsonModel, JsonRequestBehavior.AllowGet);
             

        }

      
    }
}