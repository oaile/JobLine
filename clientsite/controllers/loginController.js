'use strict'
app.controller('loginController', function($scope,loginService,$location,$cookieStore) {
   
    $scope.login = function() {
        //alert($scope.userName);
        loginService.login($scope.userName, $scope.passWord, function(response, data) {
           if(response.status == 200){
               //alert(response.data);
               alert("Login successful!");
               $cookieStore.put('username',$scope.userName);
               $location.path('/'); 
           }else {
                    alert("Login fail!");
                    $scope.error = 'Username or password is incorrect';;
                    $scope.dataLoading = false;
                }
        });
    }
});

app.controller('logoutController',function($scope,$cookieStore,$location) {
  $cookieStore.remove("username");
  $location.path('/'); 
});