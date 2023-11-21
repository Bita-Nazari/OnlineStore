(function ($) {
    function pad(n) {
        return (n < 10) ? ("0" + n) : n;
    }

    $.fn.showclock = function (startTime, endTime) {
        var currentDate = new Date();
        var futureDate = new Date(endTime);

        if (currentDate > futureDate) {
            this.hide();
            return this;
        }

        var seconds = (futureDate.getTime() - currentDate.getTime()) / 1000;

        var days = Math.floor(seconds / 86400);
        seconds = seconds % 86400;

        var hours = Math.floor(seconds / 3600);
        seconds = seconds % 3600;

        var minutes = Math.floor(seconds / 60);
        seconds = Math.floor(seconds % 60);

        var html = "";

        html += "<div class='countdown-container seconds'>"
        html += "<span class='countdown-value seconds-bottom'>" + pad(seconds) + "</span>";
        html += "<span class='countdown-heading seconds-top'>ثانیه</span>";
        html += "</div>";

        html += "<div class='countdown-container minutes'>"
        html += "<span class='countdown-value minutes-bottom'>" + pad(minutes) + "</span>";
        html += "<span class='countdown-heading minutes-top'>دقیقه</span>";
        html += "</div>";

        html += "<div class='countdown-container hours'>"
        html += "<span class='countdown-value hours-bottom'>" + pad(hours) + "</span>";
        html += "<span class='countdown-heading hours-top'>ساعت</span>";
        html += "</div>";

        if (days != 0) {
            html += "<div class='countdown-container days'>"
            html += "<span class='countdown-value days-bottom'>" + pad(days) + "</span>";
            html += "<span class='countdown-heading days-top'>روز</span>";
            html += "</div>";
        }

        this.html(html);
    };

    $.fn.countdown = function (startTime, endTime) {
        var el = $(this);
        el.showclock(startTime, endTime);
        setInterval(function () {
            el.showclock(startTime, endTime);
        }, 1000);
    }

}(jQuery));

jQuery(document).ready(function () {
    if (jQuery(".countdown").length > 0) {
        jQuery(".countdown").each(function () {
            var startTime = $(this).data('start-time');
            var endTime = $(this).data('end-time');
            jQuery(this).countdown(startTime, endTime);
        })
    }
});