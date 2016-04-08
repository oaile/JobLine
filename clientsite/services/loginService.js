'use strict'
app.service('loginService', function($rootScope,$http) {
    
    var self = this;
    self.login = function(userName,passWord, callback) {
        var data = {Username: userName, Password: passWord};
    //     $http.post('http://localhost:56081/api/user/login', data)
    //     .success(function(data, status, headers, config){
    //         //alert(data);
    //         callback(status, data);
    //         
    //         //alert("Login successful!");
    //     }).error(function(data, status, headers, config){
    //         alert(data);
    //         callback(status);
    //         //alert("Fail!");
    //     });

        $http.post('http://localhost:56081/api/user/login', data)
        .then(
            function(response){
                // success callback
                callback(response);
            }, 
            function(response){
                // failure callback
                callback(response);
            }
        );
     };
});