app.config(['$routeProvider', function($routeProvider){

    $routeProvider
        .when('/store', {
            templateUrl: './src/components/store/store.html',
            controller: 'storeCtrl'
        })
	    .when('/shopping-card', {
		    templateUrl: './src/components/shopping-card/shopping-card.html',
		    controller: 'shoppingCardCtrl'
	    })
        .otherwise({
            redirectTo: '/store'
        });
}]);

