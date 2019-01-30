var app = angular.module("VotingListApp",['onsen'])

// Set Apis EndPoint
const SERVER="http://192.168.0.65/";

// Start VotingLis Controller
app.controller("VotingListCtrl",function ($scope, $http) {
    $scope.Msg="Hi";

    // Recover Votinglist Selected information
    $scope.VtList = JSON.parse(localStorage.getItem("VListSelected"))
    debugger
    $scope.GoGroupDetails=function () {
        window.location.href="GroupDetails.html";
    }

})
// End 
