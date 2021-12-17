myApp.controller('product_detail', ($scope, $http, $rootScope) => {

    $scope.quantity = 0;
    $scope.total = 0;

    //get product detail
    $http.get('/product/GetProductDetail',
        {
            params: {
                product_id: getParameter("product_id")
            }
        }
    ).then((res) => {
        $scope.product = res.data;
        $scope.colors = JSON.parse($scope.product.colors);
        $scope.color = $scope.colors[0];
        $scope.sizes = $scope.color.sizes;
        $scope.size = $scope.sizes[0];
    }, (err) => {
        console.log(err);
    });

    //get images
    $http.get('/product/GetProductImages', {
        params: {
            product_id: getParameter("product_id")
        }
    }).then((res) => {
        $scope.images = res.data;
        console.log($scope.images);
    }, (err) => {
        console.log(err);
    });


    //bussiness
    $scope.selectColor = (index) => {
        $scope.color = $scope.colors[index];
        $scope.sizes = $scope.color.sizes;
        $scope.size = $scope.sizes[0];
    }

    $scope.setSize = (index) => {
        $scope.size = $scope.sizes[index];
    }

    $scope.getFirstColor = (index) => {
        if (index == 0)
            return "border border-primary select-border";
        return "";
    }

    $scope.setQuantity = () => {
        if ($scope.quantity < 0)
            $scope.quantity = 0;
        if ($scope.quantity > $scope.size.quantity)
            $scope.quantity = $scope.size.quantity;
        $scope.total = $scope.quantity * $scope.product.price_value * (1 - $scope.color.discount/100);
    }

    $scope.setFirstImage = (index) => {
        if (index == 0)
            return "active";
        return "";
    }

    $scope.setTotal = () => {
        console.log("hello");
    }

    //order bussiness
    $scope.addCart = () => {
        if ($scope.quantity <= 0)
            return;
        var cartItem = {
            product_name: $scope.product.product_name,
            color_name: $scope.color.color_name,
            quantity: $scope.quantity,
            size_id: $scope.size.size_id,
            size_name: $scope.size.size_value,
            img: "", //$scope.images[0].image_url,
            total: $scope.quantity * ($scope.product.price_value * (1 - $scope.color.discount / 100)),
            in_stock: $scope.size.quantity,
            unit_price: $scope.product.price_value * (1 - $scope.color.discount / 100),
            discount: $scope.color.discount
        }
        var cart = getLocalData("cart");
        var itemIndex = cart.findIndex(x => x.size_id == $scope.size.size_id);
        if (itemIndex < 0)
            cart.push(cartItem);
        else {
            if (cart[itemIndex].quantity < $scope.size.quantity)
                cart[itemIndex].quantity += 1;
        }
        saveToLocal("cart", cart);
        $rootScope.cart = getLocalData("cart");
    }

    $scope.buyNow = async () => {
        var checkLogin = await authenticate($http);
        if (checkLogin) {
            $scope.addCart();
            //location.href = "/checkout";
        }
        else {
            toastr.error("You need login in order to buy product");
        }
    }
    
});