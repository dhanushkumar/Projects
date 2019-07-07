// Code goes here

(function() {

  var app = angular.module("githubViewer");
  var MainController = function($scope, timer, $location) {

    
    $scope.username = "dhanushkumar";
    $scope.error = "";
    $scope.reposSortOrder = "-stargazers_count";
    $scope.searchTerm = "";
 
    $scope.search = function(username) {
      $location.path("/user/" + username);
    };

  };
  app.controller("MainController", MainController);
}());