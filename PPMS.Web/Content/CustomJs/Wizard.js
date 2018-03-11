$(document).ready(function () {
    //Initialize tooltips
    $('.nav-tabs > li a[title]').tooltip();

    //Wizard
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

        var $target = $(e.target);

        if ($target.parent().hasClass('disabled')) {
            return false;
        }
    });

    $(".next-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');

        var activeHref = $('.wizard .nav-tabs li.active a')[0].getAttribute("href");


        if ("#step1" == activeHref.trim()) {
            var customerSaleID = $("#customerSale").val();
            if (customerSaleID == 0) {
                alert("Please select Cutomer to make Sale !");
                return false;
            }
        }
        if ("#step2" == activeHref.trim()) {
            var customerSaleID = $("#customerFuelSale").val();
            if (customerSaleID == 0) {
                alert("Please select Fuel Type to make Sale !");
                return false;
            }
            var el = document.getElementById("customerFuelAmount");
            if (el !== null && el.value === "") {
                alert("Please enter fuel amount !");
                return false;
            }

            el = document.getElementById("customerFuelAmountCost");
            if (el !== null && el.value === "") {
                alert("Please enter fuel amount !");
                return false;
            }

            var totalCost = ($("#customerFuelAmountCost").val()) * ($("#customerFuelAmount").val());
            $("#customerFuelTotalAmountCost").val(totalCost);
        }

        if ("#step3" == activeHref.trim()) {

        }

        $active.next().removeClass('disabled');
        nextTab($active);

    });

    $(".prev-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        prevTab($active);

    });
});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}
function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}