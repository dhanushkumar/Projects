(function() {
    var timer = function($interval,$log,$location) {
    var countdownInterval = null;
    var countdown = 5;

    var start = function(seconds) {
      countdown = seconds;
      countdownInterval = $interval(decremntCountdown, 1000, countdown);
    };

    var cancel = function(){
        $interval.cancel(countdownInterval);
    };
    
    var decremntCountdown = function() {
     countdown -= 1;
    
    
      $log.info("countdownInterval called" + countdown );
      if (countdown < 1) {
        $location.path("/user/" + "angular");
      }
    };
    
    return {
      countdownInterval: countdownInterval,
      countdown: countdown,
      autoStart: start,
      cancel: cancel
    };
  }; 
  var module = angular.module("githubViewer");
  module.factory("timer", timer);
}());