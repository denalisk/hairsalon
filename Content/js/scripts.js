$(function() {
    $(".stylist-form").hide();

    $("#add-stylist").click(function() {
        $(".stylist-form").show();
    });

    $("#submit-stylist").click(function() {
        $(".stylist-form").hide();
    })
});
