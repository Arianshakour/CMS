function selectPage() {
    var input = $("#selectPageForm").serialize();
    $.ajax({
        url: "/Admin/PageComment/Index/",
        type: "Post",
        data: input,
    }).done(function (result) {
        $('#gridPageComment').empty();
        $('#gridPageComment').html(result);
    });
}
function openDetailsPageComment(id) {
    $.ajax({
        url: "/Admin/PageComment/Details/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('نمایش جزییات');
        $('#bodymodal').html(result);
    });
}
function openEditPageComment(id) {
    $.ajax({
        url: "/Admin/PageComment/Edit/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('ویرایش');
        $('#bodymodal').html(result);
    });
}
function EditPageComment() {
    var input = $("#editPageComment").serialize();
    console.log(input);
    $.ajax({
        url: "/Admin/PageComment/Edit/",
        type: "Post",
        data: input,
    }).done(function (result) {
        if (result.success == false) {
            $('#bodymodal').html(result.view);
        } else {
            $("#mymodal").hide();
            $("#gridPageComment").empty();
            $("#gridPageComment").html(result);
        }
    });
}
function openDeletePageComment(id) {
    $.ajax({
        url: "/Admin/PageComment/Delete/" + id,
        type: "GET",
        data: {}
    }).done(function (result) {
        $('#mymodal').show();
        $('#bodymodal').empty();
        $('#mymodallable').html('حذف');
        $('#bodymodal').html(result);
    });
}
function DeletePageComment() {
    var input = $("#deletePageComment").serialize();
    $.ajax({
        url: "/Admin/PageComment/Delete/",
        type: "Post",
        data: input,
    }).done(function (result) {
        $('#mymodal').hide();
        $('#gridPageComment').html(result);
    });
}