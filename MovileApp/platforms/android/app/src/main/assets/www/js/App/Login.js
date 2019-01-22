var app = angular.module('Login',['onsen']);

// Set Apis EndPoint
const SERVER="http://192.168.0.65/";

// Start Login Controller
app.controller('LoginCtrl', function ($scope, $http) {

    $scope.Email="";
    $scope.Password="";

    $scope.LoginUser = function (params) {
        
        // Start http Request to get User Info
        $http({
            method:"POST",
            url: "http://192.168.0.65/User/LoginUser",
            data:{EMAIL: $scope.Email, PASSWORD:$scope.Password}
        }).then(function (response) {
            
            // Get Api Response
            var UserData = response.data
            
            // validate if the user was founded
            if (UserData == "") {
                $scope.Msg="This user is not registered";
            } else {
                
            }
            // end user validation 

        },function ErrorCallBack(response) {
            alert("Error:");
            console.log(response);
        })
        // End http Request to get User Info

    }


});
// End Login controller
