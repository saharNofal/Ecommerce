"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();

//Disable the send button until connection is established.
/*document.getElementById("sendButton").disabled = true;*/

//connection.on("NewProductAdded", function (message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
//    // We can assign user-supplied strings to an element's textContent because it
//    // is not interpreted as markup. If you're assigning in any other way, you 
//    // should be aware of possible script injection concerns.
//    li.textContent = `Notification: ${message}`;
//});
connection.on("NewOrder", function (message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `Notification: ${message}`;
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

