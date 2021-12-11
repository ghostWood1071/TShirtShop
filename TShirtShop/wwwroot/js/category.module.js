myApp.controller("category", ($scope, $http) => {
    $http.get(`/product/GetCategories`).then((response) => {
        $scope.categories = response.data;
        console.log($scope.categories);
    }, (error) => {
        console.log(error);
    });
});

myApp.controller("category", ($scope, $http) => {
    $http.get(`/product/GetCategories`).then((response) => {
        $scope.categories = response.data;
        console.log($scope.categories);
    }, (error) => {
        console.log(error);
    });
});