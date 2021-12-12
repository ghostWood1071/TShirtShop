myApp.controller('product_detail', ($scope, $http) => {

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
    }

    $scope.setFirstImage = (index) => {
        if (index == 0)
            return "active";
        return "";
    }

    //order bussiness
    $scope.addCart = () => {

    }

    $scope.buyNow = () => {

    }
    
});