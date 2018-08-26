var mainApp = angular.module('OnionSolutionMain', ['ngRoute'])
    .config(function ($routeProvider, $locationProvider) {

        $routeProvider.when('/home', {
            templateUrl: '/Employee/Index'
        }).when('/employee', {
            templateUrl: '/Employee/Index'
            })
            .otherwise({ redirectTo: '/home' });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

mainApp.controller('OnionSolutionMainController', function ($scope, $window) {
    $scope.LoadPerson = function () {
        templateUrl:'Employee/Index'
    };
});