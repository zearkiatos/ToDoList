app.factory("UserService", ["$resource", "$location", "$http", "$q", "ToDoListResources", function (r, l, h, q, tr) {
    var userService = {};

    userService.user = {};

    userService.userSession = {};

    userService.getUser = function (name) {
        var temp = {};
        return h.get(tr.getUrl() + "/api/v1/Users/" + name).then(function (response) {
            if (typeof response.data === "object")
                return response.data;
            else
                return q.reject(response.data);

        }, function (response) {
            return q.reject(response.data);
        });
    }
    return userService;
}]); 