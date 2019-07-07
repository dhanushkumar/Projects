angular.module('app').directive('ctxHeading', function() {
  return {
    templateUrl: "heading.html",
    restrict: "E"
  }
});


angular.module('app').directive('userAddRemove', function() {
  return {
    templateUrl: "userAddRemove.html",
    restrict: "E",
    controller: function($scope) {
      $scope.addUser = function(user) {
        user = {
          name: $scope.name,
          address: {
            street: $scope.street,
            city: $scope.city,
            country: $scope.country

          }
        }
        $scope.users.push(user);
      }
    }

  }
});

angular.module('app').directive('userInfoCard', function() {
  return {
    templateUrl: "userInfoCard.html",
    restrict: "E",
    scope: {
      users: '='
    },
    controller: function($scope) {

      $scope.knightMe = function(user) {
        user.rank = "Liked!";
      }
      $scope.removeUser = function(user) {
        var index = $scope.users.indexOf(user);
        if(index > -1)
        {
          $scope.users.splice(index, 1);  
        }
      }
       $scope.removeFriend = function(selectedUser,friend) {
        var userIndex = $scope.users.indexOf(selectedUser);
        if(userIndex > -1)
        {
        var user = $scope.users[userIndex];
        var index = user.friends.indexOf(friend);
        if(index > -1)
        {
         user.friends.splice(index, 1);  
        }
        }
      }
    }
    
  }
});

angular.module('app').directive('cfxConfirmRemove', function() {
  return {
    templateUrl: "confirmRemove.html",
    restrict: "E",
    scope: {
      notifyParent: "&method"
    }
    ,
    controller: function($scope) {
     $scope.showRemove = false;
     $scope.showHideRemove = function()
     {
       $scope.showRemove = true; 
     }
      $scope.cancelRemove = function()
     {
       $scope.showRemove = false; 
     }
      $scope.confirmRemove = function()
       {
          $scope.notifyParent();
       }
    }
  }
});