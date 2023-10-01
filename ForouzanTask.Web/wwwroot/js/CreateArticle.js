function ValidateTitle() {
    var title = $('#Title').val();
    if (title.length > 0) {
        $('#p-Title').hide();
    } else {
        $('#p-Title').show();
    }
}
function ValidateTag() {
    var tag = $('#MetaDescription').val();
    if (tag.length > 0) {
        $('#p-MetaTag').hide();
    } else {
        $('#p-MetaTag').show();
    }
}
$(function () {
    'use strict';

    $('#sliderDropify').dropify();

});