myApp.controller("checkout", ($scope, $http, $rootScope) => {
    
    $scope.userInfo = getLocalData("account");
    $scope.cart = getLocalData("cart");
    $scope.fullName = "";
    $scope.phone = "";
    $scope.address = "";
    $scope.addrState = "";
    $scope.shippingType = "";

    $scope.addrStateChange = () => {
        if ($scope.addrState) {
            $scope.fullName = $scope.userInfo.full_name;
            $scope.phone = $scope.userInfo.phone;
            $scope.address = $scope.userInfo.address;
        } else {
            $scope.fullName = "";
            $scope.phone = "";
            $scope.address = "";
        }
    }

    $scope.shippingTypeClick = (value) => {
        $scope.shippingType = value;
        console.log();
    }

    $scope.checkout = () => {
        if ($scope.fullName == "" ||
            $scope.phone == "" ||
            $scope.address == "" ||
            $scope.shippingType == "" ||
            $scope.cart == null || $scope.cart == "" || $scope.cart == []) {
            return;
        }
        $http({
            method: 'post',
            headers: { "Content-Type": "application/json" },
            dataType: 'json',
            data: {
                totlal_price: $rootScope.total(),
                shipping_address: $scope.address,
                phone: $scope.phone,
                payment: $scope.shippingType,
                status: 0,
                list_details: $scope.cart.map(x => {
                    return {
                        quantity: x.quantity,
                        size_id: x.size_id,
                        total: x.total,
                        unit_price: x.total,
                        discount: x.discount
                    }
                })
            },
            url: "CreateOrder"
        }).then((res) => {
            if (res.data) {
                localStorage.removeItem("cart");
                toastr.success("order successfully");
                setTimeout(() => location.reload(), 1000);
            }
        }, (err) => {
            console.log(err.data);
        })
        
    }
});