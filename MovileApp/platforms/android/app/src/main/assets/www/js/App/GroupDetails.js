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
app.controller("VotingListCtrl", function ($scope, $http) {

    // recover Group data as a json object
    $scope.GroupInfo = JSON.parse(localStorage.getItem("GroupSelected"))
    
    // recover user infor from local storage
    $scope.UserData = JSON.parse(localStorage.getItem("UserInfo"));

    $scope.GroupName="";
    $scope.SheduleDate="";

    $scope.ErrorMessage="";

    // Get the Votation List Actives by groupId
    GetVotationList();

    $scope.CreateVotingListByGroupId=function () {     
        
        // Set the Grupo Data to register
        var GrupoData = {
            GROUPID: $scope.GroupInfo.Id,
            VLNAME:$scope.GroupName,
            SHDEULEDATE: $scope.SheduleDate,
        }

        // Start the httpRequest. to register a new voting list
        $http({
            method:"POST",
            url:SERVER +"VotingList/RegisertVotingListByGroupId",
            data:GrupoData
        }).then(function (response) {
            
            // Get api Response
            var  Response = response.data;
            debugger

            // validate api result
            if (Response != "0") {
                $scope.ErrorMessage="Other Voting list already has this same name, please write other name";
            }else{
                $scope.ErrorMessage=""
            }
            // End api result validation

        },function ErrorCallBack(response) {
            alert("Error registering the list");
            console.log(response.data);
        })
        // Start the httpRequest. to register a new voting list     
        
    }
    // End Function

    $scope.OpenVotingList = function (Votinglist) {
        
        // storage the voting list selected
        localStorage.setItem("VListSelected",JSON.stringify(Votinglist));

        // Redirect user to VotingList View
        window.location.href = "VotingListDetails.html";
    }
    // End Function

    function GetVotationList(params) {
        
        // start Http request to get the Active Votation list by GroupId
        $http({
            method:"GET",
            url:SERVER +"VotingList/GetVotationListActivesByGroupId",
            params:{GROUPID:$scope.GroupInfo.Id}
        }).then(function (response) {

            // Get api result
            $scope.VotingList= response.data;

        },function ErrorCallBack(response) {
            alert("Error To get the Voting List");
            console.log(response.data);
        })
        // start Http request to get the Active Votation list by GroupId
    }

})
// start voting List controller