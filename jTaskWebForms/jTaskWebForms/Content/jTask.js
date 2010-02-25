$.ajaxSetup({
  type: "post",
  contentType: "application/json; charset=utf-8",
  dataType: "json"
})

$(document).ready(function() {
  $('#addTask').click(function(evt) {
    evt.preventDefault();
    var dto = { name: $('#Name').val() };
    $.ajax({
      url: "/Default.aspx/AddTask",
      data: JSON.stringify(dto),
      success: function(response) {
        var task = response.d;
        $('<li>').text(task.Name)
               .attr('id', "TaskID-" + task.Id)
               .appendTo('#tasks');
      }
    });
  });



  $('#tasks li').live('click', function(evt) {
    var taskId = this.id.substring(7);
    var that = this;


    if ($(this).hasClass('done')) {
      var dto = { 'id': taskId };
      $.ajax({
        url: 'TaskService.asmx/Delete',
        data: JSON.stringify(dto),
        success: function(result) {
          if (result.d) {
            $(that).fadeOut('slow', function() {
              $(that).remove();
            });
          } 
        }
      });
    }
    else {
      $('#status').text("Working!!!!!!!!!!");
      var dto = { 'id': taskId };
      $.ajax({
        url: 'TaskService.asmx/Complete',
        data: JSON.stringify(dto),
        success: function(result) {
          var cr = result.d;
          if (cr.success) {
            $(that).addClass('done');
            $('#status').text(cr.message);
          }
          else {
            $('#status').text(cr.message);
          }
        }
      });
    }
  });
});
    