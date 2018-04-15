app.factory("BoardService", ["$resource", "$location", "$http", "$q", "ToDoListResources", function (r, l, h, q, tr) {
    var boardService = {};

    boardService.getBoards = function () {
        var temp = {};
        return h.get(tr.getUrl() + "/api/" + tr.version + "/Boards").then(function (response) {
            if (typeof response.data === "object")
                return response.data;
            else
                return q.reject(response.data);

        }, function (response) {
            return q.reject(response.data);
        });
    }

    boardService.getBoardByUser = function (userId) {
        var temp = {};
        return h.get(tr.getUrl() + "/api/" + tr.version + "/BoardByUser/"+userId).then(function (response) {
            if (typeof response.data === "object")
                return response.data;
            else
                return q.reject(response.data);

        }, function (response) {
            return q.reject(response.data);
        });
    }


    boardService.postTicket = function (datapost) {
        console.log(datapost);
        var temp = {};
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        h.post(tr.getUrl() + "/api/" + tr.version + "/TICKETs", datapost).then(function (response) {

        });
    };

    return boardService;
}]);