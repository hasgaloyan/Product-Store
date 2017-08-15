app.directive('header', ['$location', '$rootScope', 'apiSvc', function ($location, $rootScope, apiSvc) {

    return {
        restrict: 'E',
        scope: {

        },
        templateUrl: './src/directives/header/header.html',
        link: function (scope, elem, attrs) {

        	scope.count = 0;

            apiSvc.getOrderItems(apiSvc.getCookie('uid')).then(function (res) {
                console.log(res);
                scope.count = res.data.length;
            }).catch(function (err) {
                console.log(err);
                scope.count = 0;
            });

            scope.goTo = function (url) {
                $location.path(url);
            };

            scope.page = $location.path();
            $rootScope.$on('$locationChangeSuccess', function(){
                scope.page = $location.path();
            });

	        $rootScope.$on('addToCard', function (e, count) {
	        	scope.count = count;
	        });

            $rootScope.$on('removeFromCard', function () {
                scope.count--;
            })
        }
    }
}]);