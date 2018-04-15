app.config(["$routeProvider", function (r) {
    r.when("/", {
        controller: "HomeController",
        templateUrl: "Views/Home.html"
    }).when("/Board", {
        controller: "BoardController",
        templateUrl: "Views/Board.html"
    });
}]);