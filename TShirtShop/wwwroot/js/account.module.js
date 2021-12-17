myApp.controller("account", async ($scope, $http, $rootScope) => {
    $scope.auth = await authenticate($http);
    $scope.userInfo = getLocalData("account");
    if (!$scope.auth)
        $scope.infoState = "display: none";
    else
        $scope.infoState = "display: block";

    $scope.onClickLogin = () => {
        if (!$scope.auth)
            location.href = "/login";
        else
            return;
    }
});