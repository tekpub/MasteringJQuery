<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="jTaskWebForms._Default" EnableViewState="false" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="jTask.Models"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
  <head>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript" src="/Content/jTask.js"></script>
    <script type="text/javascript" src="/Content/json2.js"></script>
    <style type="text/css">
      .done {
        text-decoration: line-through;
      }
    </style>
  </head>
  <body>
    <form id="addTaskForm" runat="server">
    
    <asp:Repeater runat="server" ID="taskList">
    <HeaderTemplate><ul id="tasks">
    </HeaderTemplate>
    <ItemTemplate><li id="TaskID-<%# Eval("Id") %>"><%# Eval("Name") %></li></ItemTemplate>
      <FooterTemplate></ul>
      </FooterTemplate>
    </asp:Repeater>   
    
    <span id="status"></span>
    
    <asp:TextBox ID="Name" runat="server" />
    <asp:Button ID="addTask" runat="server" Text="Add" OnClick="addTask_Click" />
    </form>
  </body>
</html>
