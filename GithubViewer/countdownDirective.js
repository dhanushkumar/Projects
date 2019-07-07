(function() {
  angular.module('githubViewer').directive('dkCountDown',
    function() {
      return {
        templateUrl: 'countdown.html',
        restrict: 'E',
        scope: {
          notifyParent: '&method'
        },
        controller: function($scope, $interval, $log, $location) {

          var countdown = 5;
          var countdownInterval = null;

          $scope.start = function(seconds) {
           countdown = seconds;
           countdownInterval =$interval(decremntCountdown, 1000, countdown);
          };

          $scope.cancel = function() {
            $interval.cancel(countdownInterval);
          };

          var decremntCountdown = function() {
            countdown -= 1; 
            $scope.countdown = countdown;
            //$log.info("countdownInterval called" + countdown);
            if (countdown < 1) {
              //$location.path("/user/" + "angular");
              $scope.notifyParent();
            }

           
          }
        }
      }
    });
}());