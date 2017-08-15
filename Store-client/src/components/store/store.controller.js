	app.controller('storeCtrl', ['$scope', '$rootScope', 'apiSvc', '$timeout', function ($scope, $rootScope, apiSvc, $timeout) {

    $scope.productCount = [1,2,3,4,5,6,7,8,9,10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

	$scope.getProducts = function (v) {
        apiSvc.getFilteredProducts(v)
            .then(function (res) {
                console.log(res);
                $scope.products = res.data.map(function (product) {
                    product.quantity = '1';
                    return product;
                });
            })
            .catch(function (err) {
                $scope.products = [];
            });
	};

	$scope.values = {
		min : 0,
		max: 20000
	};

    $scope.userMinPrice = $scope.min;
    $scope.userMaxPrice = $scope.max;

    var time = null;

	$scope.$watch('values', function (v) {

		if (time) {
			clearInterval(time);
		}

		time = setTimeout(function () {
            console.log(v);
            $scope.getProducts(v)
		}, 500);
	}, true);

    apiSvc.getCategories()
		.then(function (res) {
			$scope.categories = res.data;
		})
		.catch(function (err) {
			console.log(err);
		});

	$scope.addToCard = function (product) {

		apiSvc.addToCard({
            ProductID: product.id,
			UID: apiSvc.getCookie('uid'),
			Quantity: parseInt(product.quantity)
		}).then(function (res) {
			console.log(res);
            $rootScope.$broadcast('addToCard', res.data);
		}).catch(function (err) {
			console.log(err);
		})
	};

	$scope.getByCatId = function (id) {
		apiSvc.getProductsFromCategory(id)
			.then(function (res) {
				res.data.map(function (product) {
					product.quantity = '1';
					return product;
				});
				$scope.products = res.data;
			})
			.catch(function (err) {
				console.log(err);
				$scope.products = [];
			})
	};


	if (!apiSvc.getCookie('uid')) {
		apiSvc.setCookie('uid', apiSvc.uid(), 7)
	}

	$scope.selectedProduct = null;

	$scope.showDetails = function (id) {
		$scope.selectedProduct = null;
		apiSvc.getProductDetails(id).then(function (res) {

			$timeout(function () {
                $scope.selectedProduct = res.data;
                console.log($scope.selectedProduct);
			}, 3000);
		}).catch(function (err) {
			console.log(err);
		});
	}
}]);