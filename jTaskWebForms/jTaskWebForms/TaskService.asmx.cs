using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using jTask.Models;

namespace jTaskWebForms
{
    /// <summary>
    /// Summary description for TaskService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class TaskService : System.Web.Services.WebService
    {
        [WebMethod]
        public CompleteResponse Complete(int id)
        {
            var repo = new TaskRepository();

            repo.Complete(id);

            var response = new CompleteResponse();
            response.success = id == 2;

            if (response.success)
                response.message = "Everything worked";
            else
                response.message = "There was an error";

            return response;
        }

        [WebMethod]
        public bool Delete(int id)
        {
            var repo = new TaskRepository();

            repo.Remove(id);

            return true;
        }

        public class CompleteResponse
        {
            public bool success { get; set; }
            public string message { get; set; }
        }
    }
}
