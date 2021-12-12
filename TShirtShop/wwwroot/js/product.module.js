

myApp.controller('product', ($scope, $http) => {

    //get categories
    $http.get(`/product/GetCategories`).then((response) => {
        $scope.categories = response.data;
    }, (error) => {
        console.log(error);
    });

    //get trending product when begin 
    $http.get(`/product/GetTrendings`, {
        params: {
            quantity: 8,
            category_id: "c868f1bc-102d-4bed-9a41-686a9d50aaaf"
        }
    }).then((response) => {
        $scope.trendings = response.data;
        console.log(response.data);
    }, (error) => {
        console.log(error);
    });

    //get sale product
    $http.get('/product/GetSales', {
        params: {
            quantity: 8
        }
    }).then((response) => {
        $scope.sales = response.data;
        console.log($scope.sales);
    }, (error) => {
        console.log(error);
    });

    //get trending product
    $scope.getTrending = (category_id) => {
        $http.get(`/product/GetTrendings`, {
            params: {
                quantity: 8,
                category_id: category_id
            }
        }).then((response) => {
            $scope.trendings = response.data;
            console.log($scope.trendings);
        }, (error) => {
            console.log(error);
        });
    }

    //get latest product
    $http.get(`/product/GetLatests`, {
        params: {
            quantity: 8
        }
    }).then((response) => {
        $scope.latests = response.data;
        console.log($scope.latests);
    }, (error) => {
        console.log(error);
    });

    //dropdown
    $scope.items = [
        { order: 'Ascending', value: 0 },
        { order: 'Decending', value: 1 }
    ];

    $scope.props = [
        { value: 'price_value', col_name: 'Price' },
        { value: 'product_name', col_name: 'Name' },
        { value: 'sold_quan', col_name: 'Hot' }]


    //sorting
    $scope.sortColumn = "price_value";
    $scope.reverse = true;
    $scope.sort = (driect) => {
        if (driect == 0)
            $scope.reverse = false;
        else $scope.reverse = true;
    }
    $scope.setSortCol = (value) => $scope.sortColumn = value;

    //pagination
    $http.get('/product/GetAllProduct', {
        params: {
            keyword: getParameter("keyword")
        }
    }).then((response) => {
        $scope.products = response.data.products;
        $scope.maxSize = 5;
        $scope.bigTotalItems = response.data.products.length;
        $scope.bigCurrentPage = 1;
        $scope.pageChange();
    }, (err) => {
        console.log(err);
    })

    $scope.pageChange = () => {
        var s = $scope.bigCurrentPage;
        var start = 50 * (s - 1);
        var end = start + 49;
        if (start > $scope.products.length - 1)
            return;
        if (end > $scope.products.length - 1)
            end = $scope.products.length - 1;
        $scope.product_paged = $scope.products.slice(start, end + 1);
    }

    $scope.loadLabelName = (item) => {
        if (item.discount > 0)
            return `SALE OFF -${item.discount}%`;
        if (item.isnew == 1)
            return "New";
    }

    $scope.loadLabelVal = (item) => {
        if (item.discount > 0)
            return `price-dec`;
        if (item.isnew == 1)
            return "new";
    }
});