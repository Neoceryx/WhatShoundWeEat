var app = angular.module('Login',['onsen']);

// Start Login Controller
app.controller('LoginCtrl', function ($scope) {

    $scope.Email="";
    $scope.Password="";

    $scope.LoginUser = function (params) {
        $scope.Email;
        $scope.Password;
        debugger

    }


});
// End Login controller
