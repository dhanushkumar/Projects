// Code goes here

(function() {

  var app = angular.module("githubViewer");
  var MainController = function($scope, github, timer, $log) {

    var person = {
      firstName: "Dhanush",
      lastName: "Paramanathan",
      imageSrc: "https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwizlbixvf7cAhUBzVMKHf6UDN4QjRx6BAgBEAU&url=https%3A%2F%2Fwww.photo.net%2F3664580&psig=AOvVaw22gJkFfnqLlcpLhZZZOY6Y&ust=1534951952396882"
    };
    $scope.person = person;
    $scope.message = "Github Viewer";
    $scope.username = "angular";
    $scope.error = "";
    $scope.reposSortOrder = "-stargazers_count";
    $scope.searchTerm = "";

    $log.info("countdown " + $scope.countdown);

    var onUserComplete = function(data) {
      $scope.user = data;
      github.getRepos(data).then(onRepos, onError);
    };

    var onRepos = function(data) {
      $scope.repos = data;
    };

    var onError = function(data) {
      $scope.error = data;
    };

    $scope.search = function(username) {
      var user = github.getUser(username);
      github.getUser(username).then(onUserComplete, onError);
      $log.info("searching for user " + username);
    };

    timer.start(15);
    $scope.countdown = timer.countdown;
    $scope.countdownInterval = timer.countdownInterval;
  };
  app.controller("MainController", MainController);
}());