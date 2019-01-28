var app = angular.module("DashApp",['onsen']);

// start Dashboard controller controller
app.controller("DashCtrl",function ($scope, $http) {

    // Set Apis EndPoint
    const SERVER="http://192.168.0.65/";

    // recover user infor from local storage
    $scope.UserData = JSON.parse(localStorage.getItem("UserInfo"));
    
    $scope.GroupName="";

    // load all Groups by UserId
    GetMyGroups();
    
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
                debugger
                // validate api result
                switch (Result[0]) {

                    case "0":
                        // close the create new group dialog
                        this.newGroup.hide();

                        // Redirect user to Group Details View
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

    $scope.OpenGroupById=function (GroupId) {
        
        this.myNavigator.pushPage('groupInfo.html', {data: {groupId: GroupId}})
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

    
});
// End Dashboard controller

app.controller("GroupCtrl", function ($scope, $http) {
    
    // Set Apis EndPoint
    const SERVER="http://192.168.0.65/";

    // recover user infor from local storage
    $scope.UserData = JSON.parse(localStorage.getItem("UserInfo"));

    var pullHook = document.getElementById('pull-hook');
    debugger
    pullHook.addEventListener('changestate', function (event) {
        var message = '';

        switch (event.state) {
            case 'initial':
                message = 'Pull to refresh';
                break;
            case 'preaction':
                message = 'Release';
                GetMyGroups();
                break;
            case 'action':
                message = 'Loading...';
                break;
        }

        pullHook.innerHTML = message;
    });

    pullHook.onAction = function (done) {
        setTimeout(done, 5000);
    };

    
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

})