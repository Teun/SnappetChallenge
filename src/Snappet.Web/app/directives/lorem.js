angular.module('cvdApp')

.directive('lorem', [

    function () {
        return {
            restrict: 'E',
            replace: true,
            template:
                '<span>' +
                '<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus et molestie ex. Donec a sem vitae purus venenatis elementum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent tempor ipsum felis, nec finibus augue vehicula vitae. Cras ut tempus ligula. Nullam auctor dictum ante vel porta. Proin luctus sem ut purus ultricies, eget tincidunt tortor consectetur. Nulla finibus ut nunc non dignissim.</p>' +
                '<p>Duis quis libero pulvinar, interdum massa ac, rutrum ex. Fusce eget hendrerit sem, non viverra libero. Ut hendrerit nibh ut lorem pharetra pharetra nec a sem. Nulla sed odio dictum, ultricies nisi vel, faucibus purus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean felis nibh, dictum non mi nec, laoreet iaculis nisl. Cras pretium mollis diam, at viverra ante ultricies et. Proin fringilla ipsum bibendum, pellentesque nisi eu, placerat nulla. Proin vehicula erat eu turpis pretium aliquet. Vestibulum semper in odio et viverra.</p>' +
                '</span>'
        }
    }
]);
