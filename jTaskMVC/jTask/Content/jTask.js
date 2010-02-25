$(document).ready(function() {

  $('#addTaskForm').ajaxForm({
    dataType: 'json',
    success: function(response) {
      $('<li>').text(response.Name)
               .attr('id', "TaskID-" + response.Id)
               .appendTo('#tasks');
    }
  });

  $('#tasks li').live('click', function(evt) {
    var taskId = this.id.substring(7);
    var that = this;


    if ($(this).hasClass('done')) {
      $.post('/Home/Delete', { 'id': taskId }, function(result) {
        if (result) {
          $(that).fadeOut('slow', function() {
            $(that).remove();
          });
        }
      }, "json");

    }
    else {
      $('#status').text("Working!!!!!!!!!!");

      $.post('/Home/Complete', { 'id': taskId }, function(result) {
        if (result.success) {
          $(that).addClass('done');
          $('#status').text(result.message);
        }
        else {
          $('#status').text(result.message);
        }

      }, "json");
    }
  });
});
    