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

    s.user = JSON.parse(localStorage.getItem("currentUserData")).user;
    console.log(s.user);
    if (s.user == null) {
        localStorage.removeItem("currentUserData");
        location.href = "/";
    }

    bs.getBoardByUser(s.user.id).then(function (data) {
        s.tasks = data[0];
        s.model.task.board_id = s.tasks.TICKET[0].board_id;
        console.log(s.tasks.TICKET[0]);
    });

    s.addTask = function () {
        //var data = {
        //        "board_id": s.tasks.TICKET[0].board_id,
        //        "title": s.model.task.title,
        //        "decription": s.model.task.description,
        //        "date": getFullDate(),
        //        "estimated_time": s.model.task.estimated_time
        //    };
        console.log(getFullDate());
        var data = {
            'title': s.model.task.title,
            'description': s.model.task.description,
            'date': getFullDate().toString(),
            'estimated_time': s.model.task.estimated_time,
            'board_id': s.tasks.TICKET[0].board_id
        };

        bs.postTicket(data);

        s.tasks = {};

        bs.getBoardByUser(s.user.id).then(function (data) {
            s.tasks = data[0];
            console.log(s.tasks.TICKET[0]);
        });

        s.model.task = {};

        $("#addTaskModal .close").click();
    }
    
}]);