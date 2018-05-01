//IIFE
(function () {
  var size = 15;
  var page = 0;

  $("document").ready(function () {

    function loadStudentsIdSelect() {
      $("#child-ids").ready(function () {
        $.get("http://localhost:26975/api/getStudents", function (data, status) {
          setIdOptions(data);
        });
      });
    }

    function setIdOptions(studentsId) {
      studentsId.forEach(id => {
        $('#child-ids').append($('<option>', {
          value: id,
          text: id
        }));
      });
    }

    function setFilterClick() {
      $('#filter').on('click', function () { loadStudentWork($('#child-ids').val(), true) });
    }

    function setLoadMoreClick() {
      $('#load-more').on('click',function () { loadStudentWork(0) });
    }

    function loadStudentWork(studentId, resetTable) {
      var from = $("#fromdate").val();
      var to = $("#todate").val();
      $.get("http://localhost:26975/api/getWork?from=" + from + '&to=' + to +
        "&page=" + page + "&pageSize=" + size + "&studentId=" + (studentId ? studentId : 0),
        function (data, status) {
          resetTable && $("#work-content").html('')
          setNewRows(data);
          page++;
        });
    }

    function setNewRows(works) {
      works.forEach(work => {
        //$(this).closest('tr').after('<tr><td>new td<td></tr>');
        var correct = work.correct;
        var difficulty = work.difficulty;
        var domain = work.domain;
        var exerciseId = work.exerciseId;
        var learningObjective = work.learningObjective;
        var subject = work.subject;
        var submit = work.submitDateTime;
        var date = new Date(submit);
        var formattedSubmitDate = date.getMonth() + '/' + date.getDate() + '/' + date.getFullYear()
          + ' ' + date.getHours() + ':' + date.getMinutes();
        var submittedAnswerId = work.submittedAnswerId;
        var userId = work.userId;
        $('#work-content').append('<tr>');
        $('#work-content tr:last').
          append('<td>' + submittedAnswerId +
            '<td>' + formattedSubmitDate +
            '<td>' + correct +
            '<td>' + userId +
            '<td>' + exerciseId +
            '<td>' + difficulty +
            '<td>' + subject +
            '<td>' + domain +
            '<td>' + learningObjective);
      });
    }


    loadStudentsIdSelect();
    loadStudentWork();
    setFilterClick();
    setLoadMoreClick();
  });
})();
