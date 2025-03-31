function logoutform() {
    $.ajax({
        url: "/Login/LoadLogout",
        type: "Get",
        data: {}
    }).done(function (result) {
        $('#mymodal').modal('show');
        $('#mymodallable').html('آیا برای خروج اطمینان دارید ؟');
        $('#bodymodal').html(result);
    });
}
function logoutPost() {
    $.ajax({
        url: "/Login/Logout",
        type: "POST",
        data: {},
    }).done(function (result) {
        console.log(result);
        $('#mymodal').modal('hide');
        window.location.href = '/Login/Login';
    });
}

function ShowNewsByGroup(gid, gti) {
    var decodedTitle = decodeURIComponent(gti); // دیکد کردن عنوان در سمت کلاینت
    console.log(decodedTitle);
    console.log(gti);
    //ye moqe didi khata dare mitooni bjaye gti az decodedTitle estefade koni
    //hatman yadet bashe vaqti parameter az jense string mikhai bdi be method to ajax
    //hatman injoori bezar onclick="koft(@item.GroupId,'@(Uri.EscapeDataString(item.GroupTitle))')"
    //var URL = "/Group/" + gid + "/" + gti;
    var URL = "/Home/ShowNewsById/" + gid + "/" + gti;
    $.ajax({
        url: "/Home/ShowNewsById/?id=" + gid + "&title=" + gti,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#safe').empty();
        $('#safe').html(result);
        history.replaceState(null, null, URL);
    });
}

function ShowNews(id) {
    var URL = "/Home/ShowNews/" + id;
    $.ajax({
        url: "/Home/ShowNews/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#safe').empty();
        $('#safe').html(result);
        history.replaceState(null, null, URL);
    });
}
function HomeBtn() {
    var URL = "/";
    $.ajax({
        url: "/Home/Index/",
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#safe').empty();
        $('#safe').html(result);
        InitializeSlider();
        history.replaceState(null, null, URL);
    });
}
function SearchBtn() {
    var searchValue = $('#search').val();
    var URL = "/Home/Index/?search=" + searchValue;
    $.ajax({
        url: "/Home/Index/",
        type: "GET",
        data: { search: searchValue }
    }).done(function (result) {
        console.log(result);
        $('#safe').empty();
        $('#safe').html(result);
        InitializeSlider();
        history.replaceState(null, null, URL);
    });
}
//in function baraye doros load shodan slider hast
function InitializeSlider() {
    $('#slider-one').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        items: 1,
        navText: [
            '<i class="fa fa-caret-left"></i>', // دکمه قبلی
            '<i class="fa fa-caret-right"></i>' // دکمه بعدی
        ]
    });
}
function ArchiveBtn() {
    var URL = "/Home/Archive/";
    $.ajax({
        url: "/Home/Archive/",
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#safe').empty();
        $('#safe').html(result);
        history.replaceState(null, null, URL);
    });
}

function LoginBtn() {
    var URL = "/Login/Login/";
    $.ajax({
        url: "/Login/Login/",
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#safe').empty();
        $('#safe').html(result);
        history.replaceState(null, null, URL);
    });
}

function RegisterBtn() {
    var URL = "/Login/Register/";
    $.ajax({
        url: "/Login/Register/",
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#safe').empty();
        $('#safe').html(result);
        history.replaceState(null, null, URL);
    });
}