// Code goes here
angular.module('app', []);

angular.module('app').controller('mainCtrl', function($scope) {
  $scope.users = [{
    name: 'DK',
    address: {
      street: 'somewher Avenue',
      city: 'Atlanta',
      country: 'usa'
    },
    friends: [
      'Dennis',
      'Jason',
      'Chris',
      'Jane',
    ]
  }, {
    name: 'Vish Run',
    address: {
      street: 'Piedemont Avenue',
      city: 'Alpharetta',
      country: 'USA'
    },
    friends: [
      'Dennis',
      'Shane',
      'Warne',
      'Mackie',
    ]
  }];
});