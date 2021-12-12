myApp.controller("cart", ($scope, $http, $rootScope) => {
    $rootScope.cart = getLocalData("cart");
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
});
