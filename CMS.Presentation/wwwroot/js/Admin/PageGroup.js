function openCreatePageGroup() {
    $.ajax({
        url: "/Admin/PageGroup/Create/",
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('افزودن');
        $('#bodymodal').html(result);
    });
}
function CreatePageGroup() {
    var input = $('#addPageGroup').serialize();
    console.log(input);
    $.ajax({
        url: "/Admin/PageGroup/Create/",
        type: "Post",
        data: input,
    }).done(function (result) {
        debugger;
        if (result.success == false) {
            $('#bodymodal').html(result.view);
        } else {
            $("#mymodal").hide();
            $("#gridPageGroup").empty();
            $("#gridPageGroup").html(result);
        }
    });
}
function openDetailsPageGroup(id) {
    $.ajax({
        url: "/Admin/PageGroup/Detail/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('نمایش جزییات');
        $('#bodymodal').html(result);
    });
}
function openEditPageGroup(id) {
    $.ajax({
        url: "/Admin/PageGroup/Edit/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('ویرایش');
        $('#bodymodal').html(result);
    });
}
function EditPageGroup() {
    var input = $("#editPageGroup").serialize();
    $.ajax({
        url: "/Admin/PageGroup/Edit/",
        type: "Post",
        data: input,
    }).done(function (result) {
        if (result.success == false) {
            alert("لطفا اطلاعات را کامل پر کنید ");
            $('#bodymodal').html(result.view);
        } else {
            $("#mymodal").hide();
            $("#gridPageGroup").empty();
            $("#gridPageGroup").html(result);
        }
    });
}
function openDeletePageGroup(id) {
    $.ajax({
        url: "/Admin/PageGroup/Delete/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('حذف');
        $('#bodymodal').html(result);
    });
}
function DeletePageGroup() {
    var input = $("#deletePageGroup").serialize();
    $.ajax({
        url: "/Admin/PageGroup/Delete/",
        type: "Post",
        data: input,
    }).done(function (result) {
        $('#mymodal').hide();
        $('#gridPageGroup').html(result);
    });
}