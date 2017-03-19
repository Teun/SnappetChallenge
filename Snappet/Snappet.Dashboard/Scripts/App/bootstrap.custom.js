/*
Original snippet with some adjustments from:
http://bootsnipp.com/snippets/featured/collapsible-panel
*/
$(document).on('click', '.panel-heading', function (e) {
    var $this = $(this);
    var slideSpeed = 50;
    var panel = $this.parent('.panel');
    var toggleElements = panel.find('.toggle');
    if (!$this.hasClass('panel-collapsed')) {
        toggleElements.slideUp(slideSpeed);
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
    }
    else {
        toggleElements.slideDown(slideSpeed);
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
    }
});