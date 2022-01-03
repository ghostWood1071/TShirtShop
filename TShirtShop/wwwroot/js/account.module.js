myApp.controller("account", async ($scope, $http, $rootScope) => {
    $scope.auth = await authenticate($http);
    console.log($scope.auth);
    $scope.userInfo = getLocalData("account");
    if ($scope.auth)
        $scope.infoState = "display: block";
    else
        $scope.infoState = "display: none";

    $scope.onClickLogin = () => {
        if (!$scope.auth)
            location.href = "/login";
        else
            return;
    }
});