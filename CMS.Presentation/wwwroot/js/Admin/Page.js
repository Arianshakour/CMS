function selectGroupPage() {
    var input = $("#selectGroupPageForm").serialize();
    $.ajax({
        url: "/Admin/Page/Index/",
        type: "GET",
        data: input,
    }).done(function (result) {
        $('#gridPage').empty();
        $('#gridPage').html(result);
    });
}
function openCreatePage() {
    $.ajax({
        url: "/Admin/Page/Create/",
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('افزودن');
        $('#bodymodal').html(result);
    });
}

function CreatePage() {
    var formData = new FormData($('#addPage')[0]);//serialize faqat baraye matni hast age ax o File dari FormData bezar
    $.ajax({
        url: "/Admin/Page/Create/",
        type: "Post",
        data: formData,
        processData: false,// baraye ine ke be jquery bgim tabdil nakon be txt chon pishfarz tabdil mikone be matni
        contentType: false,// hatman bezar ta bezare multipart/form-data ersal beshe
    }).done(function (result) {
        if (result.success == false) {
            $('#bodymodal').html(result.view);
        } else {
            $("#mymodal").hide();
            $("#gridPage").empty();
            $("#gridPage").html(result);
        }
    });
}
function openDetailsPage(id) {
    $.ajax({
        url: "/Admin/Page/Detail/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('نمایش جزییات');
        $('#bodymodal').html(result);
    });
}
function openEditPage(id) {
    $.ajax({
        url: "/Admin/Page/Edit/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('ویرایش');
        $('#bodymodal').html(result);
    });
}
function EditPage() {
    var formData = new FormData($('#editPage')[0]);
    $.ajax({
        url: "/Admin/Page/Edit/",
        type: "Post",
        data: formData,
        processData: false,
        contentType: false,
    }).done(function (result) {
        if (result.success == false) {
            alert("لطفا اطلاعات را کامل پر کنید ");
            $('#bodymodal').html(result.view);
        } else {
            $("#mymodal").hide();
            $("#gridPage").empty();
            $("#gridPage").html(result);
        }
    });
}
function openDeletePage(id) {
    $.ajax({
        url: "/Admin/Page/Delete/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('حذف');
        $('#bodymodal').html(result);
    });
}
function DeletePage() {
    var input = $("#deletePage").serialize();
    $.ajax({
        url: "/Admin/Page/Delete/",
        type: "Post",
        data: input,
    }).done(function (result) {
        $('#mymodal').hide();
        $('#gridPage').html(result);
    });
}