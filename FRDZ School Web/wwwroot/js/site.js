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
        if (scrollOffset > (heroHeight - 700)) {
            hero.addClass('fixme');
        } else {
            hero.removeClass('fixme');
        };
    });
}
heroShinker();

/*===============================================================================================*/

//function FixTable(table) {
//	var inst = this;
//	this.table = table;

//	$('tr > th', $(this.table)).each(function (index) {
//		var div_fixed = $('<div/>').addClass('fixtable-fixed');
//		var div_relat = $('<div/>').addClass('fixtable-relative');
//		div_fixed.html($(this).html());
//		div_relat.html($(this).html());
//		$(this).html('').append(div_fixed).append(div_relat);
//		$(div_fixed).hide();
//	});

//	this.StyleColumns();
//	this.FixColumns();

//	$(window).scroll(function () {
//		inst.FixColumns()
//	}).resize(function () {
//		inst.StyleColumns()
//	});
//}

//FixTable.prototype.StyleColumns = function () {
//	var inst = this;
//	$('tr > th', $(this.table)).each(function () {
//		var div_relat = $('div.fixtable-relative', $(this));
//		var th = $(div_relat).parent('th');
//		$('div.fixtable-fixed', $(this)).css({
//			'width': $(th).outerWidth(true) - parseInt($(th).css('border-left-width')) + 'px',
//			'height': $(th).outerHeight(true) + 'px',
//			'left': $(div_relat).offset().left - parseInt($(th).css('padding-left')) + 'px',
//			'padding-top': $(div_relat).offset().top - $(inst.table).offset().top + 'px',
//			'padding-left': $(th).css('padding-left'),
//			'padding-right': $(th).css('padding-right')
//		});
//	});
//}

//FixTable.prototype.FixColumns = function () {
//	var inst = this;
//	var show = false;
//	var s_top = $(window).scrollTop();
//	var h_top = $(inst.table).offset().top;

//	if (s_top < (h_top + $(inst.table).height() - $(inst.table).find('.fixtable-fixed').outerHeight()) && s_top > h_top) {
//		show = true;
//	}

//	$('tr > th > div.fixtable-fixed', $(this.table)).each(function () {
//		show ? $(this).show() : $(this).hide()
//	});
//}

//$(document).ready(function () {
//	$('.fixtable').each(function () {
//		new FixTable(this);
//	});
//});

/*===============================================================================================*/

document.addEventListener('DOMContentLoaded', () => {

    const getSort = ({ target }) => {
        const order = (target.dataset.order = -(target.dataset.order || -1));
        const index = [...target.parentNode.cells].indexOf(target);
        const collator = new Intl.Collator(['en', 'ru'], { numeric: true });
        const comparator = (index, order) => (a, b) => order * collator.compare(
            a.children[index].innerHTML,
            b.children[index].innerHTML
        );

        for (const tBody of target.closest('table').tBodies)
            tBody.append(...[...tBody.rows].sort(comparator(index, order)));

        for (const cell of target.parentNode.cells)
            cell.classList.toggle('sorted', cell === target);
    };

    document.querySelectorAll('.table_sort thead').forEach(tableTH => tableTH.addEventListener('click', () => getSort(event)));

});
