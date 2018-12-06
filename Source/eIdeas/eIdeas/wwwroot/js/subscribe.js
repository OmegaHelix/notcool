"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/subscribeHub").build();

connection.on("ReceiveMessage", function (user, message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    alert(message + user);
    //var encodedMsg = message + user;
    //var span = document.createElement("span");
    //span.textContent = encodedMsg;
    //document.getElementById("subcribeBox").appendChild(span);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

var sub = document.getElementsByClassName("subscribe");
for (var i = 0; i < sub.length ; i++)
{
    sub[i].addEventListener("click", function (event) {
    var user = event.currentTarget.getAttribute("name");
    var message = "you are subscribed to ";
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});    
}  