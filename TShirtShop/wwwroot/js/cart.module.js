myApp.controller("cart", ($scope, $http, $rootScope) => {
    $rootScope.cart = getLocalData("cart");
    $scope.accInfo = getLocalData("account");
    $rootScope.total = () => {
        var s = 0
        for (var i = 0; i < $rootScope.cart.length; i++)
            s += $rootScope.cart[i].total;
        return s;
    }
    $rootScope.remove = (index) => {
        $rootScope.cart.splice(index, 1);
        saveToLocal("cart", $rootScope.cart);
    }
    $scope.plus = (index) => {
        var t = $rootScope.cart[index].quantity + 1;
        if (t > $rootScope.cart[index].in_stock) {
            return;
        }
        $rootScope.cart[index].quantity = t;
        $rootScope.cart[index].total = $rootScope.cart[index].quantity * $rootScope.cart[index].unit_price;
        saveToLocal("cart", $rootScope.cart);
    }

    $scope.minus = (index) => {
        var t = $rootScope.cart[index].quantity - 1;
        if (t <=0) {
            return;
        }
        $rootScope.cart[index].quantity = t;
        $rootScope.cart[index].total = $rootScope.cart[index].quantity * $rootScope.cart[index].unit_price;
        saveToLocal("cart", $rootScope.cart);
    }
});
