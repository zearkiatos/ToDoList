app.controller("HomeController", ["$scope", "$rootScope", "$http", "$location", "UserService", function (s,r,h,l,us) {
    s.greetings = "Hello World!";
}]);