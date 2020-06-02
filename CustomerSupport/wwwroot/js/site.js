// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function solved() {
    // Get the checkbox
    var checkBox = document.getElementById("solved_table_" + arguments[0]);

    // If the checkbox is checked, then update the solved-field in controller
    if (checkBox.checked == true)
    {
        var theUrl = '/Task/Update/'+arguments[0];
        window.location = theUrl;
    }
}