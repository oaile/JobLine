'use strict'
var app = angular.module('app',['ngRoute','ngCookies']);

app.config(['$routeProvider', function($routeProvider) {
    $routeProvider
    .when('/login', {
        templateUrl: 'views/login.html',
        controller: 'loginController'
      })
	  .when('/home', {
        templateUrl: 'views/home.html',
        controller: 'homeController'
      })
      .when('/logout', {
        templateUrl: 'views/login.html',
        controller: 'logoutController'
      })
	  .otherwise({
        redirectTo: '/home'
      });
  }]);
  

