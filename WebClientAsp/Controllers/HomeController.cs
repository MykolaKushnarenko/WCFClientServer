using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClientAsp.CodeCompare;
using WebClientAsp.Models;

namespace WebClientAsp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ServiceContractClient _client = new ServiceContractClient();
        public ActionResult Index()
        {
            return View();
        }
     
        [HttpPost]
        public  ActionResult Upload(CompareInfo infoCode)
        {
            AddingCodeObject parem = new AddingCodeObject(); 
            byte[] code;
            var a = infoCode.Address;
            var s = infoCode.Person;
            if (infoCode.upload != null)
            {
                using (StreamReader reader = new StreamReader(infoCode.upload.InputStream))
                {
                    code = reader.CurrentEncoding.GetBytes(reader.ReadToEnd());
                    
                }

                parem.Name = infoCode.Person;
                parem.CompileType = infoCode.Language;
                parem.FileMane = infoCode.upload.FileName;
                parem.Code = code;
                parem.IsSearch = true;
                parem.Description = infoCode.Address;

            }

            var res = _client.AddCodeAsync(parem).Result;
            ViewBag.Result = res;
            ViewBag.Space = "\n";
            return View("~/Views/Home/ResCompare.cshtml");
        }

        public ActionResult ResCompare()
        {
            return View();
        }
    }
}