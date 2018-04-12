app.factory("ToDoListResources", ["$resource", "$location", function (r, l) {

    var toDoListResource = {};

    //toDoList.user this object storage the user than have session active.
    toDoList.user = {};

    //Web api URL head.
    toDoList.url = "http://localhost:3641/";


    /**
    * Summary. 
    *
    * Description. This function is to get the user than have session activer.
    *
    * @since      11.04.2018
    * @return toDoList.user object with the principal menu data.
    */
    toDoList.getUser = function () {
        return toDoList.user;
    }

    /**
    * Summary. 
    *
    * Description. This function is to get the url web api head.
    *
    * @since      11.04.2018
    * @return toDoList.url string with the url web api head.
    */
        toDoList.getUrl = function () {
            return toDoList.url;
        }
        return toDoList;
}]);
