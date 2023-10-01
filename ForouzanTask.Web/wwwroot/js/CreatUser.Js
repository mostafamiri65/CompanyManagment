function ValidateFullName() {
    var fullname = $('#FullName').val();
    if (fullname.length > 0) {
        $('#h-FullName').hide();
    } else {
        $('#h-FullName').show();

    }
}
function ValidateUserName() {
    var fullname = $('#UserName').val();
    if (fullname.length > 0) {
        $('#h-UserName').hide();
    } else {
        $('#h-UserName').show();

    }
}

function ValidateMobile() {
    var fullname = $('#Mobile').val();
    if (fullname.length > 0) {
        $('#h-Mobile').hide();
    } else {
        $('#h-Mobile').show();

    }
}
function ValidateMobile() {
    var fullname = $('#Mobile').val();
    if (fullname.length > 0) {
        $('#h-Mobile').hide();
    } else {
        $('#h-Mobile').show();

    }
}
function ValidatePass() {
    var fullname = $('#Password').val();
    var repass = $('#RePassword').val();
    if (fullname.length > 0 &&repass.length>0) {
        $('#h-pass').hide();
    } else {
        $('#h-pass').show();
    }
}
