app.controller("BoardController", ["$scope", "$rootScope", "$http", "$location", "BoardService", function (s, r, h, l, bs) {
    s.user = {};
    s.tasks = [];
    s.model = {};
    s.model.task = {};
    s.model.task.title = "";
    s.model.task.description = "";
    s.model.task.date = "";
    s.model.task.estimated_time = 0;
    s.model.task.board_id = 0;
    s.temp = {};
    r.deleteItem = 0;
    s.user = JSON.parse(sessionStorage.getItem("user")).user;
    console.log(s.user);
    if (s.user == null) {
        sessionStorage.removeItem("user");
        location.href = "/";
    }

    bs.getBoardByUser(s.user.id).then(function (data) {
        s.tasks = data[0];
        s.model.task.board_id = s.tasks.TICKET[0].board_id;
        console.log(s.tasks.TICKET[0]);
    });

    s.addTask = function () {

        var data = {
            'title': s.model.task.title,
            'description': s.model.task.description,
            'date': getFullDate().toString(),
            'estimated_time': s.model.task.estimated_time,
            'board_id': s.tasks.TICKET[0].board_id
        };
        s.temp = {
            "id": s.tasks.TICKET[s.tasks.TICKET.length - 1].id + 1,
            "REL_TICKET_HAS_STATUS": [{
                "STATUS": {
                    "id": 4
                }
            }],
            "title": s.model.task.title,
            "description": s.model.task.description,
            "date": getFullDate().toString(),
            "estimated_time": s.tasks.TICKET[0].board_id
        };

        console.log(s.temp);
        s.tasks.TICKET.push(s.temp);

        s.model.task = {};
        try {
            bs.postTicket(data);
        }
        catch (err) {
            console.log(err);
        }
        finally {
            l.path("/");
            $("#addTaskModal .close").click();
            $(".modal-backdrop").hide();
        }
        
    }

    s.openEditModal = function (datapost) {
        console.log(datapost);
        $("#edittitle").val(datapost.title);
        $("#editdescription").val(datapost.description);
        $("#editestimated_time").val(datapost.estimated_time);
        s.model.task.id = datapost.id;
        s.model.task.board_id = datapost.REL_TICKET_HAS_STATUS[0].STATUS.id;
        s.model.task.title = datapost.title;
        s.model.task.description = datapost.description;
        s.model.task.date = datapost.date;
        s.model.task.estimated_time = datapost.estimated_time;
        localStorage.removeItem("dataput");
        datapost.board_id = datapost.REL_TICKET_HAS_STATUS[0].STATUS.id;
        localStorage.setItem("dataput", JSON.stringify(s.model.task));
    };

    s.editTask = function () {
        var temp = JSON.parse(localStorage.getItem("dataput"));
        console.log(temp.board_id);
        var data = {
            'id': temp.id,
            'title': $("#edittitle").val(),
            'description': $("#editdescription").val(),
            'date': temp.date,
            'estimated_time': $("#editestimated_time").val(),
            'board_id': s.tasks.TICKET[0].board_id
        };
        console.log(data);
        bs.putTicket(temp.id, data);

        $.each(s.tasks.TICKET, function (key, value) {
            if (value.id == temp.id) {
                value.REL_TICKET_HAS_STATUS[0].STATUS.id = s.model.task.board_id;
                value.title = s.model.task.title;
                value.description = s.model.task.description;
                value.date = s.model.task.date;
                value.estimated_time = s.model.task.estimated_time;
            }
        });
        l.path("/");
        $("#editTaskModal .close").click();
        $(".modal-backdrop").hide();

    };

    s.changeStatus = function (ticketId, statusId) {
        bs.changeStatus(ticketId, statusId);
    };


    s.deleteTask = function (ticketId) {
        console.log(ticketId);
        r.deleteItem = ticketId;
    };

    s.deleteTicket = function () {
        bs.deleteTicket(r.deleteItem);
        $("#"+r.deleteItem).remove();
        $("#deleteTaskModal .close").click();
    }
}]);