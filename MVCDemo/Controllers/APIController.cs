using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        public JsonResult Titles()
        {
            return new JsonResult()
            {
                Data = EnumToDictionary(typeof(Models.Title)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet

        };
            
        }

        public JsonResult Skills()
        {
            return new JsonResult
            {
                Data = EnumToDictionary(typeof(Models.Skill)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult Statuses()
        {
            return new JsonResult
            {
                Data = EnumToDictionary(typeof(Models.Status)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult Websites()
        {
            return new JsonResult
            {
                Data = EnumToDictionary(typeof(Models.Website)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        private string EnumToDictionary(System.Type typeOfEnum)
        {
            var result = new Dictionary<int, string>();
            foreach (var val in Enum.GetValues(typeOfEnum))
            {
                result.Add((int)val, val.ToString());
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}