(function() {

  var app = angular.module("githubViewer");

  var RepoController = function($scope, $routeParams, github) {

    var reponame = $routeParams.reponame;
    var username = $routeParams.username;
   
    var onComplete = function(data) {
      $scope.repo = data;
    };
    var onError = function(reason) {
      $scope.error = reason;
    };
     github.getRepoDetails(username, reponame).then(onComplete, onError);
  };
  
  app.controller("RepoController", RepoController);

}());