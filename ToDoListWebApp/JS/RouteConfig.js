app.config(["$routeProvider", function (r) {
    r.when("/", {
        controller: "HomeController",
        templateUrl: "Views/Home.html"
    });
}]);