adminModule.controller("login", ($scope, $http) => {
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
            url: "/admin/login/checkaccount"
        }).then((res) => {
            var check = res.data;
            if (check != "") {
                //saveToLocal("account", check);
                location.href = "/admin";
            }
            else {
                toastr.error("Account or password is in correct");
            }
        }, (err) => {
            console.log(err.data);
        });
    }
});