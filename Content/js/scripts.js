$(function() {
    $(".client-edit-button").click(function() {
        $(this).parent().hide();
        $(this).parent().next().show();
    });
    $(".client-cancel-button").click(function() {
        $(this).parent().hide();
        $(this).parent().prev().show();
    });
    $(".collapsible-header").click(function() {
        $(".client-info").show();
        $(".client-edit").hide();
    });

    $('.my-but').click(function() {
        console.log("clicked submit");
    });

    $('.collapsible').collapsible();
    $('select').material_select();
});
