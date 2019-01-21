var app = angular.module('Login',['onsen']);

// Start Login Controller
app.controller('LoginCtrl', function ($scope) {

    $scope.LoginUser = function (params) {
        alert("Hi");
    }


});
// End Login controller
