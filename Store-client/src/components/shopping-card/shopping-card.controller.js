app.controller('shoppingCardCtrl', ['$scope', 'apiSvc', '$rootScope', function ($scope, apiSvc, $rootScope) {

	$scope.checkoutData = {};
	$scope.productCount = [1,2,3,4,5,6,7,8,9,10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

	$scope.removeFromCard = function (index, product) {

		apiSvc.deleteOrderItem(product.id).then(function (res) {
			console.log(res);
            $scope.products.splice(index, 1);
            $rootScope.$broadcast('removeFromCard');
        }).catch(function (err) {
			console.log(err);
        });
	};

	$scope.changeQuantity = function (p) {

		console.log(p);

        apiSvc.updateOrderItem({
            id: p.id,
            quantity: parseInt(p.quantity)
        }).then(function (res) {
            console.log(res);
        }).catch(function (err) {
            console.log(err);
        })
    };

	apiSvc.getOrderItems(apiSvc.getCookie('uid')).then(function (res) {

		$scope.products = res.data.map(function (p) {
			p.total = p.quantity * p.price;
			return p;
		});

        console.log($scope.products);
    }).catch(function (err) {
		console.log(err);
		$scope.products = [];
    });

	$scope.checkout = function () {
		console.log($scope.checkoutData);
		$scope.checkoutData.OrderDate = apiSvc.dateNow();
		$scope.checkoutData.Username = apiSvc.getCookie('uid');
        $('#checkout-modal').modal('hide');

		apiSvc.checkout($scope.checkoutData).then(function (res) {
			console.log(res);
			$scope.products = [];
            $rootScope.$broadcast('addToCard', 0);
			alert('You have successfully placed your order');
            $('#checkout-modal').modal('hide');
		}).catch(function (err) {
			console.log(err);
			alert('something goes wrong');
            $('#checkout-modal').modal('hide');
		});
	}
}]);