/**
 * Summary.
 *
 * Function definition to all utilities than use into the web application.
 *
 * @file   This files define all function and utilities into web application.
 * @author Pedro Capriles
 * @since  13.04.2018
 */
/*Loading JQuery scope.*/

$(document).ready(function () {
    /**
    * Summary. 
    *
    * Description. Boostrap anonymous function than will execute when the page load.
    *
    * @since      13.04.2018
    * @fires   onload
    * @listens event:onload
    */
    $("#notifications").hide();


});

function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.appendChild(document.getElementById(data));
}

function getFullDate() {
    var d = new Date();
    return d.getFullYear() + "-" + d.getMonth() + "-" + d.getDay() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds() + "." + d.getMilliseconds();
}