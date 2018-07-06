//lists users and have checkbox to mark as done

"option strict";

function loaded() {
    $.getJSON("http://localhost:59378/Lists/List")
        .done(function (resp) {
            console.log(resp);
            display(resp.Data);
            listIt = resp;
        });
}

function display(tasks) {
    var tbody = $("tbody");
    tbody.html("");
    for (var task of tasks) {
        var tr = $("<tr></tr>");
        tr.append($("<td>" + task.User.Name + "</td>"));
        tr.append($("<td>" + task.Name + "</td>"));
        tr.append($("<td><button class='btn btn-danger' onclick='completed(" + task.Id + ", \"" + task.Name.trim() + "\", " + task.Completed + ");'>Completed</button></td>"));
        tbody.append(tr);
    }
}

function completed(taskid, taskname, taskcompleted) {

    var item = 
        {
            Id: taskid,
            Name: taskname,
            Completed: taskcompleted,
            UserId: 1
        };
    $.post("http://localhost:59378/Lists/Remove/", item)
        .done(function (resp) {
            console.log(resp);
        });
    loaded();
}