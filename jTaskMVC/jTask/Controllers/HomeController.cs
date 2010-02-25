using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jTask.Models;

namespace jTask.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new TaskRepository();
            ViewData["Tasks"] = repo.FindAll();
            return View();
        }

        public ActionResult AddTask(Task task)
        {
            var repo = new TaskRepository();
            repo.Add(task);

            if(Request.IsAjaxRequest())
            {
                return Json(task);
            }

            return new RedirectResult("/Home");
        }

        public ActionResult Complete(int id)
        {
            var repo = new TaskRepository();
            
            repo.Complete(id);

            var response = new CompleteResponse();
            response.success = id == 2;
            
            if(response.success)
             response.message = "Everything worked";
            else
             response.message = "There was an error";
            
            return Json(response);
        }

        public ActionResult Delete(int id)
        {
            var repo = new TaskRepository();

            repo.Remove(id);

            return Json(true);
        }
    }

    public class CompleteResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
}
