var app = angular.module("DashApp",[]);

// start Dashboard controller controller
app.controller("DashCtrl",function ($scope, $http) {

    // Set Apis EndPoint
    const SERVER="http://192.168.0.65/";

    // recover user infor from local storage
    var UserData = JSON.parse(localStorage.getItem("UserInfo"));
    debugger

    function GetMyGroups() {
        
        // Start http request to get all muy groups
        $http({
            method:"GET",
            url: SERVER+""
        })
        // Start http request to get all muy groups    

    }

    
});
// End Dashboard controller