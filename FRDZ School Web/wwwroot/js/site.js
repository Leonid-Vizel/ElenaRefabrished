function onEntry(entry) {
    entry.forEach(change => {
        if (change.isIntersecting) {
            change.target.classList.add('element-show');
        }
    });
}
let options = { threshold: [1.0] };
let observer = new IntersectionObserver(onEntry, options);
let elements = document.querySelectorAll('.element-animation');
for (let elm of elements) {
    observer.observe(elm);
}

/*=============================================================================================*/

var heroShinker = function () {
    var hero = $('.hero-nav'),
        heroHeight = $('.hero-nav').outerHeight(true);
    $(hero).parent().css('padding-top', heroHeight);
    $(window).scroll(function () {
        var scrollOffset = $(window).scrollTop();
        if (scrollOffset < heroHeight) {
            $(hero).css('height', (heroHeight - scrollOffset));
        }
        if (scrollOffset > (heroHeight - 300)) {
            hero.addClass('fixme');
        } else {
            hero.removeClass('fixme');
        };
    });
}
heroShinker();

var heroShinker = function () {
    var hero = $('.hero-navE'),
        heroHeight = $('.hero-navE').outerHeight(true);
    $(hero).parent().css('padding-top', heroHeight);
    $(window).scroll(function () {
        var scrollOffset = $(window).scrollTop();
        if (scrollOffset < heroHeight) {
            $(hero).css('height', (heroHeight - scrollOffset));
        }
        if (scrollOffset > (heroHeight - 115)) {
            hero.addClass('fixme');
        } else {
            hero.removeClass('fixme');
        };
    });
}
heroShinker();

/*===============================================================================================*/
