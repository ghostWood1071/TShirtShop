myApp.controller("login", ($scope, $http, $rootScope) => {
    $scope.account = "";
    $scope.password = "";

    $scope.login = () => {
        if ($scope.account == "" || $scope.password == "")
            return false;
        $http({
            method: 'post',
            params: {
                account: $scope.account,
                password: $scope.password
            },
            url: "/login/checkaccount"
        }).then((res) => {
            var check = res.data;
            if (check != "") {
                saveToLocal("account", check);
                location.href = "/";
            }
            else {
                toastr.error("Account or password is in correct");
            }
        }, (err) => {
            console.log(err.data);
        });
    }
});