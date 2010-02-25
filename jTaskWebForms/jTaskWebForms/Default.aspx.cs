using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using jTask.Models;

namespace jTaskWebForms
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindRepeater();
        }
        
        protected void addTask_Click(object sender, EventArgs e)
        {
            var repo = new TaskRepository();
            repo.Add(new Task() { Name = Name.Text });
        }

        protected void BindRepeater()
        {
            var repo = new TaskRepository();
            taskList.DataSource = repo.FindAll();
            taskList.DataBind();
        }

        [WebMethod]
        public static Task AddTask(string name)
        {
            var repo = new TaskRepository();
            var task = new Task() {Name = name};
            repo.Add(task);
            return task;
        }
    }
}
