$(function() {
    $("#sidebar").load("include/sidebar.html");
    $("#header").load("include/header.html");
});
$(document).ready(function() {
    $('[data-toggle="tooltip"]').tooltip();
});
$(document).ready(function() {
    $(".collapse-menu").click(function() {
        alert("test");
        $("#sidebar").toggleClass("menu-collapsed");
    });
});
