// Code goes here

(function() {

  var app = angular.module("githubViewer");
  var UserController = function($scope, github, $routeParams, $log) {

    $scope.username = $routeParams.username;
   
    $scope.reposSortOrder = "-stargazers_count";
 
    $log.info("countdown " + $scope.countdown);

    var onUserComplete = function(data) {
      $scope.user = data;
      github.getRepos(data).then(onRepos, onError);
    };

    var onRepos = function(data) {
      $scope.repos = data;
    };

    var onError = function(data) {
      $scope.error = $scope.username + " " + data.statusText + "!";
    };
    
    github.getUser($scope.username).then(onUserComplete, onError);
  };
  app.controller("UserController", UserController);
}());