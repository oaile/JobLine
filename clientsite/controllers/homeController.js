'use strict'
app.controller('homeController',function($scope,$cookieStore) {
   $scope.userName = $cookieStore.get("username");
   //alert($cookieStore.get("username"));
});
app.directive('userDisplay', function($cookieStore) {
  
     
   //$scope.$watch('userName', function(newVal, oldVal){
        if($cookieStore.get("username") != undefined){
            return {
                template: '<li><a>{{userName}}</a></li> <li><a href="#logout">Logout</a></li>'
            };
        }else{
            return {
                template: '<li><a href="#login">Login</a></li>'
            };
        }
    //});
});