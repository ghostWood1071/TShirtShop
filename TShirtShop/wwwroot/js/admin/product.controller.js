adminModule.controller("product", ($scope, $http) => {
    $scope.category_id = null;
    $scope.sizeValue = null;
    $scope.quantity = 0;
    $scope.sizeValues = ['S', 'M', 'L', 'XL', 'XXL', 'Over'];
    $scope.colors = [];
    $scope.sizes = [];
    $scope.product = null;
    $scope.colorName = "";
    $scope.colorHex = "";
    $scope.discount = 0;
    $scope.selectedColor = -1;
    $scope.product_name = "";
    $scope.release_date = null;
    $scope.price = 0;

    $http.get(`/product/GetCategories`).then((response) => {
        $scope.categories = response.data;
        console.log($scope.categories);
    }, (error) => {
        console.log(error);
    });
    $http.get('/product/getallproduct').then((response) => {
        $scope.products = response.data;
        console.log($scope.products);
    }, (error) => {
        console.log(error);
    })

    $scope.change = (value) => {
        console.log(value);
    }
    $scope.addColor = () => {
        $scope.colors.push({
            color_id: null,
            product_id: null,
            color_name: $scope.colorName,
            color_value: $scope.colorHex,
            discount: $scope.discount
        });
    }
    $scope.addSize = () => {
        $scope.sizes.push({
            color_id: null,
            size_id: null,
            size_value: $scope.sizeValue,
            quantity: $scope.quantity
        })
        $scope.colors[$scope.selectedColor].sizes = $scope.sizes;
        console.log($scope.selectedColor)
        console.log($scope.colors[$scope.selectedColor]);
        //$scope.colors[$scope.selectedColor].sizes = $scope.sizes;
    }
    $scope.delSize = (index) => {
        $scope.sizes.splice(index, 1);
    }

    $scope.delColor = (index) => {
        $scope.colors.splice(index, 1);
    }

    $scope.selectColor = (index) => {
        $scope.selectedColor = index;
        $scope.sizes = $scope.colors[$scope.selectedColor].sizes == undefined ? [] : $scope.colors[$scope.selectedColor].sizes;
        console.log($scope.selectedColor);
    }

    $scope.addProduct = () => {
        $scope.product = {
            product_id: null,
            product_name: $scope.product_name,
            price: $scope.price,
            release_date: $scope.release_date,
            category_id: $scope.category_id,
            colors: $scope.colors
        }
        console.log($scope.product);
    }
});