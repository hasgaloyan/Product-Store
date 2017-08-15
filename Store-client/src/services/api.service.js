app.service('apiSvc', ['$http', 'API_V1', function ($http, API_V1) {

	return {

        getFilteredProducts: function (params) {
        	if (!params) return $http.get(API_V1 + '/products');
            return $http.get(API_V1 + '/products?gt=' + params.min + '&lt=' + params.max);
        },

        getCategories: function () {
            return $http.get(API_V1 + '/products/categories')
        },

		getProductsFromCategory: function (catId) {
            return $http.get(API_V1 + '/products/' + catId)
		},

		addToCard: function (product) {
			return $http.post(API_V1 + '/shoppingcard', product)
		},

		getOrderItems: function (uid) {
        	return $http.get(API_V1 + '/shoppingcard?uid=' + uid)
		},

		deleteOrderItem: function (id) {
        	return $http.delete(API_V1 + '/shoppingcard/' + id);
		},

		updateOrderItem: function (data) {
        	return $http.put(API_V1 + '/shoppingcard?id=' + data.id + '&quantity=' + data.quantity);
		},

		checkout: function (data) {
        	return $http.post(API_V1 + '/orders', data)
		},

		getProductDetails: function (id) {
        	return $http.get(API_V1 + '/products/details?productID=' + id);
		},

		dateNow: function () {

            var d = new Date();
            var datestring = ("0" + d.getDate()).slice(-2) + "-" + ("0"+(d.getMonth()+1)).slice(-2) + "-" +
                d.getFullYear() + " " + ("0" + d.getHours()).slice(-2) + ":" + ("0" + d.getMinutes()).slice(-2);

            return datestring;
		},



		s4: function () {
			return Math.floor((1 + Math.random()) * 0x10000)
				.toString(16)
				.substring(1);
		},

		uid: function () {
			return this.s4() + this.s4() + '-' + this.s4() + '-' + this.s4() + '-' +
				this.s4() + '-' + this.s4() + this.s4() + this.s4();
		},

		setCookie: function (name,value,days) {
			var expires = "";
			if (days) {
				var date = new Date();
				date.setTime(date.getTime() + (days*24*60*60*1000));
				expires = "; expires=" + date.toUTCString();
			}
			document.cookie = name + "=" + value + expires + "; path=/";
		},

		getCookie: function (name) {
			var nameEQ = name + "=";
			var ca = document.cookie.split(';');
			for(var i=0;i < ca.length;i++) {
				var c = ca[i];
				while (c.charAt(0)==' ') c = c.substring(1,c.length);
				if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
			}
			return null;
		},

		eraseCookie: function (name) {
			this.setCookie(name,"",-1);
		}
	}
}]);