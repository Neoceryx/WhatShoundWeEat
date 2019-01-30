var app = angular.module("GpApp",["onsen"]);

// Set Apis EndPoint
const SERVER="http://192.168.0.65/";

// Start GroupDetails controller
app.controller("GpCtrl",function ($scope) {

    // recover Group data as a json object
    $scope.GroupInfo = JSON.parse(localStorage.getItem("GroupSelected"))
    
     // recover user infor from local storage
     $scope.UserData = JSON.parse(localStorage.getItem("UserInfo"));

     $scope.GoDashBoard=function () {
        window.location.href = "Dashboard.html";
     }
     // End Function


})
// End GroupDetails controller

// start voting List controller
app.controller("VotingListCtrl", function ($scope) {

    // recover Group data as a json object
    $scope.GroupInfo = JSON.parse(localStorage.getItem("GroupSelected"))

    // recover user infor from local storage
    $scope.UserData = JSON.parse(localStorage.getItem("UserInfo"));

    $scope.CreateVotingListByGroupId=function () {
        
    }
    // End Function

})
// start voting List controller