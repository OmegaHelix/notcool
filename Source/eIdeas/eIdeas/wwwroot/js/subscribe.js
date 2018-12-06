"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/subscribeHub").build();
var Commentconnection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();

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




Commentconnection.on("ReceiveUpdateComment", function (userName, ideaId, userComment, getPic) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    alert(userComment + userName + ideaId);
    //var encodedMsg = message + user;
    //var span = document.createElement("span");
    //span.textContent = encodedMsg;
    //document.getElementById("subcribeBox").appendChild(span);
    $("#comments-list-" + ideaId).append("< div class= \"card\" style = \"border-color: darkgrey\"><div class=\"media\"><div class=\"media-body\"><h5 class=\"mt-0\">" + userName + "</h5>" + userComment + "</div></div></div >");
});

Commentconnection.start().catch(function (err) {
    return console.error(err.toString());
});

var sub = document.getElementsByClassName("commentForm");
for (var i = 0; i < sub.length; i++) {
    sub[i].addEventListener("submit", function (event) {

        var form = event.currentTarget;
        var ideaId = form.IdeaID.value;
        var userComment = form.UserComment.value;
        var userId = form.UserID.value;
        Commentconnection.invoke("SendUpdateComment",  userId,  ideaId,  userComment).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();

    });
}  