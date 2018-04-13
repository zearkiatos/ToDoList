app.factory("ToDoListResources", ["$resource", "$location", function (r, l) {

    var toDoListResource = {};

    //toDoList.user this object storage the user than have session active.
    toDoListResource.user = {};

    //Web api URL head.
    toDoListResource.url = "http://localhost:3641/";


    /**
    * Summary. 
    *
    * Description. This function is to get the user than have session activer.
    *
    * @since      11.04.2018
    * @return toDoList.user object with the principal menu data.
    */
    toDoListResource.getUser = function () {
        return toDoListResource.user;
    }

    /**
    * Summary. 
    *
    * Description. This function is to get the url web api head.
    *
    * @since      11.04.2018
    * @return toDoList.url string with the url web api head.
    */
        toDoListResource.getUrl = function () {
            return toDoListResource.url;
        }
    return toDoListResource;
}]);
