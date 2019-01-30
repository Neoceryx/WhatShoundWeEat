var app = angular.module("DashApp",['onsen']);

// Set Apis EndPoint
const SERVER="http://192.168.0.65/";

// start Dashboard controller controller
app.controller("DashCtrl",function ($scope, $http) {

    // recover user infor from local storage
    $scope.UserData = JSON.parse(localStorage.getItem("UserInfo"));
    
    $scope.GroupName="";

    // load all Groups by UserId
    GetMyGroups();
    
    // get the list of Groups where the user is a guest
    GetGroupusInvitedByUserId();

    // get Dom element to allow refresh pulldown
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
                GetMyGroups();
                break;
        }

        pullHook.innerHTML = message;
    });
    
    $scope.CreateNewGroup=function () {
        
        // validate register group form fields
        if ($scope.newGroupfrm.$valid) {
            
            // Start http request to register the new group
            $http({
                method:"POST",
                url:SERVER+"Group/RegisterNewGroup",
                data:{GROUPNAME: $scope.GroupName, USERNAME: $scope.UserData.USRNAME}
            }).then(function (response) {
                
                // get Api response
                var Result = response.data.split(":");
                
                // validate api result
                switch (Result[0]) {

                    case "0":
                        // close the create new group dialog
                        this.newGroup.hide();

                        // Clear Group Name    
                        $scope.GroupName = "";
                        
                        // Redirect user to Group Details View and pass the gruopid created to the view
                        this.myNavigator.pushPage('groupInfo.html', {data: {groupId: Result[1]}})

                        break;

                    case "1":                        
                        ons.notification.toast('This User is Invalid. your session will be closed', { timeout: 5000, animation: 'fall' });
                        
                        // redirect user to login screen after 2 seconds
                        setTimeout(function () {                            
                            window.location.href = "index.html";
                        }, 4000)
                        break;

                    case "2":
                        ons.notification.toast('you allready has other group whit the same name', { timeout: 3000, animation: 'fall' });
                        break;
                
                    default:
                        break;
                }
                // End validate api result

            },function ErrorCallBack(response) {
                alert("Error while the new group was registered");
                console.log(response);
            })
            // End http request to register the new group
                        
        }
        // End fields validation

    }
    // End function

    $scope.logOutUser=function () {
        
        // clear user data
        localStorage.clear();
        
        // Redirect User to Login View
        window.location.href = "index.html";

    }
    // End function

    $scope.OpenGroupById=function (Group) {

        // save the group selected in local storage
        localStorage.setItem('GroupSelected', JSON.stringify(Group))
        
        // redirect user to GroupDetails View
        window.location.href = "GroupDetails.html";
        
    }

    function GetMyGroups() {
        
        // Start http request to get all muy groups
        $http({
            method:"POST",
            url: SERVER+"Group/GetActivesGroupsByUserId",
            data:{USERNAME: $scope.UserData.USRNAME}
        }).then(function (response) {
            
            // get Groups list
            $scope.Groups = response.data
            
        },function ErrorCallBack(response) {
            alert("Error to get your Groups");
            console.log(response.data);
        })
        // Start http request to get all muy groups    

    }
    // End Function

    function GetGroupusInvitedByUserId() {
        
        // Start http request to get the gropus where the user is member
        $http({
            method:"POST",
            url:SERVER+"Group/GetInvitedGroupsActivesByUserId",
            data:{USERNAME:$scope.UserData.USRNAME}
        }).then(function (response) {

            $scope.GropusInvited=response.data;
           
        },function ErrorCallBack(response) {
            alert("Error to get the groups invited list");
            console.log(response.data);
        })
        // End http request to get the gropus where the user is member
    }
    // End Function

    
});
// End Dashboard controller


