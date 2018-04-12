app.factory("UserService", ["$resource", "$location", "$http", "$q", "ToDoListResource", function (r, l, h, q, tr) {
    var userService = {};

    userService.user = {};

    userService.userSession = {};

    userService.getUser = function (name) {
        var temp = {};
        h.get(tr.getUrl() + "/api/v1/Users/" + name).then(function (response) {
            localStorage.setItem("response", JSON.stringify(response.data));
            temp = localStorage.getItem("response");

        }, function (data, status, headers, config) {
            console.log("Error------" + JSON.stringify(data) + " " + status);
        }, {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json',
                    'Access-Control-Allow-Headers': 'Content-Type'
                }
            });
        userService.user = JSON.parse(localStorage.getItem("response"));
        console.log(userService.user);
        localStorage.setItem("currentUserData", JSON.stringify(userService.user));
        localStorage.removeItem("response");
        return userService.user;
    }
    return userService;
}]); 