myApp.controller("account", ($scope, $http, $rootScope) => {
    $scope.userInfo = getLocalData("account");
    if ($scope.userInfo == null || $scope.userInfo == "" || $scope.userInfo == [])
        $scope.infoState = "display: none";
    else
        $scope.infoState = "display: block";
    $scope.onClickLogin = () => {
        if ($scope.userInfo == null || $scope.userInfo == "" || $scope.userInfo == [])
            location.href = "/login";
        else
            return;
    }
});