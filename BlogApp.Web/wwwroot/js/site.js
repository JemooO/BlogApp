// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();

connection.on("ReceiveMessage", function (message) {
    var msg = $.parseJSON(message);
    alert("The content is " + msg.Content + "\r the address is localhost/posts/"+msg.TargetUrl);
});

connection.start().then(function () {
    alert('connected !');
}).catch(function (err) {
    alert('error happend: error is ' + err.toString());
});

