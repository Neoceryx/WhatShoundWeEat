var app = angular.module('Login',['onsen']);

// Set Apis EndPoint
const SERVER="http://192.168.0.65/";

// Start Login Controller
app.controller('LoginCtrl', function ($scope, $http) {

    $scope.UsrName="";
    $scope.Password="";

    $scope.LoginUser = function () {
        
        // Start http Request to get User Info
        $http({
            method:"POST",
            url: "http://192.168.0.65/User/LoginUser",
            data:{USRNAME: $scope.UsrName, PASSWORD:$scope.Password}
        }).then(function (response) {
            debugger
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

    $scope.OpenSigIn = function () {
        
        myNavigator.pushPage('Signin.html')
    }

});
// End Login controller

// Start SignIn Controller
app.controller('SignInCtrl', function ($scope, $http) {
    
    $scope.Gender="";

    $scope.Msg="SignIn controler Say hello";

})
// End SignIn Controller
