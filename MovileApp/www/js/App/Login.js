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
    
    $scope.PersonalName ="";
    $scope.Surnames="";
    $scope.UserName = "";
    $scope.Password = "";
    $scope.Email="";
    $scope.Gender="";

    $scope.CreateNewAccount = function() {
        
        // Get Info from New user form 
        var _data = {
            PNAME:$scope.PersonalName,
            SNAME:$scope.Surnames,
            USRNAME:$scope.UserName,
            PASS:$scope.Password,
            EMAIL:$scope.Email,
            GENDER:$scope.Gender
        }
        // End New User info

        // verify that form fields has the right value
        if ($scope.usrForm.$valid) {
            
            // Start http request to register new user
            $http({
                method: "POST",
                url: SERVER + "User/RegisterUser",
                data: _data
            }).then(function (response) {
                debugger
                // get the Api response
                var Result = response.data;

                // validate api response
                switch (Result) {

                    case 0:
                        console.log("new user was registered");                    
                        break;

                    case 1:
                        ons.notification.alert("The User Name " + $scope.UserName + " Allready is in Use. Please write a different user name")
                        break;

                    case 2:
                        ons.notification.alert("The Email " + $scope.Email + " Allready is registered.")
                        break;

                    default:
                        break;
                }
                // End Api Response

            }, function ErrorCallBack(response) {
                alert("Something happend while the user wa registered");
                console.log(response);
            })
        // End http request to register new user


        }
        // End Fields validations 
         
    }
    // End function

})
// End SignIn Controller
