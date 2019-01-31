var app = angular.module("VotingListItemApp",['onsen'])

// Set Apis EndPoint
const SERVER="http://192.168.0.65/";

// Start VotingLis Controller
app.controller("VotingListItemsCtrl",function ($scope, $http) {
    $scope.Msg="Hi";

    // Recover Votinglist Selected information
    $scope.VtList = JSON.parse(localStorage.getItem("VListSelected"))
      
    // recover user infor from local storage
    $scope.UserData = JSON.parse(localStorage.getItem("UserInfo"));

    $scope.PlaceName="";

    $scope.ErrorMsg="";

    // Display the item on Voting list    
    GetItemsVotesByListId();
    
    $scope.GoGroupDetails=function () {
        window.location.href="GroupDetails.html";
    }
    // End Function

    $scope.AddPlacesByVotingListId=function () {
        
        // Call form register Fields Validations
        if ($scope.myForm.$valid) {

            // Get the Data to will be send to add new item to the voting list
            var Data = {
                ITEMNAME:$scope.PlaceName,
                VLISTID:$scope.VtList.Id,
                USERNAME:$scope.UserData.USRNAME
            } 
            
            // start httpRequest to Add the item to the list
            $http({
                method:"POST",
                url:SERVER + "VotingListItem/AddItemByVotingListId",
                data:Data
            }).then(function (response) {
                
                // Get api Result
                var Result = response.data;

                // Validate api result
                switch (Result) {
                    case "00":

                        // Display User Message
                        ons.notification.toast('Invalid User. you will be redirected to login screen', { timeout: 1000, animation: 'fall' })
                        
                        // Redirect user to login screen after 1.5 sec
                        setTimeout(function () {
                            window.location.href="index.html"
                        },1500)

                        break;

                    case "0":
                        // Display User Message
                        ons.notification.toast('New Item was added to the list', { timeout: 2000, animation: 'fall' })                        
                        
                        // Clear form and Error Message
                        $scope.PlaceName=""
                        $scope.ErrorMsg="";

                        // Hide New Place Dialog
                        this.newPlaces.hide();

                        break;
                
                    default:
                        $scope.ErrorMsg="This place already appears on this list, please type a different place"
                        break;
                }

            },function ErrorCallBack(response) {
                alert("Error to add the item in the list");
                console.log(response.data);
            })
            // start httpRequest to Add the item to the list
            
        }else{

            // change touches attr to true to display field Validation Message
            $scope.myForm.pname.$touched = true
        }
        // End Form Register fields validation

    }
    // End function

    function GetItemsVotesByListId() {
        
        // Start httpRequest. got get the list of items on a voting list
        $http({
            method:"POST",
            url:SERVER+"VotingListItem/GetItemsByVotingListId",
            data:{VLISTID:$scope.VtList.Id}
        }).then(function (response) {
            
            $scope.Items= response.data;
            console.table($scope.Items);

        },function ErrorCallBack(response) {
            alert("Error to Display the Item on the list");
            console.log(response.data);
        })
        // Start httpRequest. got get the list of items on a voting list

    }

    var pullHook = document.getElementById('pull-hook');

    pullHook.addEventListener('changestate', function (event) {
        var message = '';

        switch (event.state) {
            case 'initial':
                message = 'Pull to refresh';
                break;
            case 'preaction':
                message = 'Release';
                break;
            case 'action':
                message = 'Loading...';
                // Refresh the Items on the voting list
                GetItemsVotesByListId();
                break;
        }

        pullHook.innerHTML = message;
    });

    pullHook.onAction = function (done) {
        setTimeout(done, 1000);
    };

})
// End 
