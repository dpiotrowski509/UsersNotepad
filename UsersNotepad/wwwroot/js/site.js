$(function () {
    $(document)
        .ajaxSend(function (event, jqxhr, settings) {
            if (settings.type.toUpperCase() != "POST") return;
            jqxhr.setRequestHeader('RequestVerificationToken', $(".AntiForge" + " input").val())
        });

    $('button[data-toggle="ajax-createUser"').click(function (e) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            $('#createUserModal').html(data);
            $('#createUserModal').find('#createUser').modal('show');
        });
    });
    $('button[data-toggle="ajax-editUser"').click(function (e) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            $('#editUserModal').html(data);
            $('#editUserModal').find('#editUser').modal('show');
        });
    });
    $('p[data-toggle="ajax-editUser"').click(function (e) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            $('#editUserModal').html(data);
            $('#editUserModal').find('#editUser').modal('show');
        });
    });
    $('button[data-toggle="ajax-deleteUser"').click(function (e) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            $('#deleteUserModal').html(data);
            $('#deleteUserModal').find('#deleteUser').modal('show');
        });
    });

    $('button[data-toggle="ajax-generateReport"').click(function (e) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            $('#generateReportModal').html(data);
            $('#generateReportModal').find('#generateReport').modal('show');
        });
    });

    $('#generateReportModal').on('click', '[data-dismiss="GenerateReport"]', function (e) {
        $('#generateReportModal').find('#generateReport').modal('hide');
    });

    $('#createUserModal').on('click', '[data-dismiss="CreateUser"]', function (e) {
        $('#createUserModal').find('#createUser').modal('hide');
    });

    $('#editUserModal').on('click', '[data-dismiss="EditUser"]', function (e) {
        $('#editUserModal').find('#editUser').modal('hide');
    });

    $('#deleteUserModal').on('click', '[data-dismiss="DeleteUser"]', function (e) {
        $('#deleteUserModal').find('#deleteUser').modal('hide');
    });

});


