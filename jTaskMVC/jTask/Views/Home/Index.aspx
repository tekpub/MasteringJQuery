<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="jTask.Models"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
  <head>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript" src="/Content/jquery.form.js"></script>
    <script type="text/javascript" src="/Content/jTask.js"></script>
    <style type="text/css">
      .done {
        text-decoration: line-through;
      }
    </style>
  </head>
  <body>
    <ul id="tasks">
    <% foreach (var task in (List<Task>) ViewData["Tasks"])
       { %>
      <li id="TaskID-<%= task.Id %>"><%= task.Name %></li>
    <%} %>
    </ul>
    <span id="status"></span>
    <form id="addTaskForm" action="/Home/AddTask" method="post">
    <input type="text" id="Name" name="Name" />
    <input type="submit" id="addTask" />
    </form>
  </body>
</html>