app.controller("HomeController", ["$scope", "$rootScope", "$http", "$location", "UserService", function (s,r,h,l,us) {
    s.user = {};

    console.log(sessionStorage.getItem("user"));

    if (sessionStorage.getItem("user")) {
        s.user = JSON.parse(sessionStorage.getItem("user"));
        console.log(s.user);
        l.path("/Board");
    }

    s.message = "";
    s.model = {};
    s.model = {
        "user": {
            "id": 0,
            "name": "",
        },
    };

    /**
    * Summary. 
    *
    * Description. Angular Scope anonymous function than will execute when the user click "Enviar" button.
    *
    * @since      13.04.2018
    * @fires   onclick
    * @listens event:onclick
    */
    s.logIn = function () {
        console.log(s.model.user.name);
        us.getUser(s.model.user.name).then(function (data) {
            sessionStorage.removeItem("user");
            sessionStorage.setItem("user", JSON.stringify(data));
            s.user = data;
            if (s.user != null) {
                if (s.user.name.toUpperCase() == s.model.user.name.toUpperCase()) {

                    s.model = {};
                    s.model = {
                        "user": {
                            "id": s.user.id,
                            "name": s.user.name
                        }
                    };
                    sessionStorage.removeItem("user");
                    sessionStorage.setItem("user", JSON.stringify(s.model));
                    console.log(s.model);
                    console.log("Login is success.");
                    location.href = "/"
                }
                else {
                    s.model = {};
                    s.message = "El usuario ingresado es incorrepto.";
                    $("#notifications").show();
                    setTimeout(function () {
                        $("#notifications").hide();
                    }, 5000);
                    console.log("login is not success.");
                }

            }
            else {
                s.model = {};
                s.message = "Ocurrio un error de comunicación intente nuevamente.";
                $("#notifications").show();
                setTimeout(function () {
                    $("#notifications").hide();
                }, 5000);
                console.log("login is not success.");
            }
        }, function (error) {
            console.log(error);
            s.message = "Disculpe a ocurrido un error, intente más tarde.";
            //s.message = error.description;
            //switch (error.errorId) {
            //    case -1:
            //        s.message = "Registro no existente.";
            //        break;
            //    case -2:
            //        s.message = "Disculpe, el usuario y/o la clave son incorreptos.";
            //        break;
            //    default:
            //        s.message = "Ocurrio un error de comunicación intente nuevamente.";

            //}
            $("#notifications").show();
            setTimeout(function () {
                $("#notifications").hide();
            }, 5000);
        });


    }

    /**
* Summary. 
*
* Description. Angular Scope anonymous function than will execute when the user click "Volver" button. This function is for close user session.
*
* @since      19.03.2018
* @fires   onclick
* @listens event:onclick
*/
    s.LogUp = function () {
        sessionStorage.removeItem("user");
        s.user = {};
        s.model = {};
        location.href = "/";
    }
}]);