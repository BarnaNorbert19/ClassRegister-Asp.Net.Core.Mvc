$(document).ready(function () {
    onUsersPageLoad();
    onCoursesPageLoad();
});

function onUsersPageLoad() {
    if (window.location.pathname == "/Admin/Users") {

        document.querySelector('#add-btn').addEventListener('click', event => {
            document.getElementsByClassName("modal-title")[0].textContent = "Add user";
            $("#UserInfo_Id").val(null);
            $("#user-form-btn").html("Add");
            $("#user-form").attr("action", "/Admin/AddUser");
        });

        var userEditClick = function () {
            document.querySelectorAll('.edit-link').forEach(item => {
                item.addEventListener('click', event => {
                    $(".modal-title").html("Edit user");
                    $("#user-form-btn").html("Save");
                    $("#user-form").attr("action", "/Admin/EditUser");

                    var id = event.target.parentElement.children[1].href.split("/")[event.target.parentElement.children[1].href.split("/").length - 1];
                    $("#UserInfo_Id").val(id);
                });
            });
        };

        loadPartialView("LoadUsers", "#user-list", userEditClick);
        $("#user-spinner").remove();
    }
}

function onCoursesPageLoad() {
    if (window.location.pathname == "/Admin/Courses") {
        loadPartialView("LoadCourses", "#courses-list");
    }
}

function loadPartialView(url, replace) {
    $.ajax({
        type: "POST",
        url: url,
        data: $("form").serialize(),
        success: function (data) {
            onSuccessDelegate
            $(replace).html(data);


        }
    });
}

function loadPartialView(url, replace, onSuccessDelegate) {
    $.ajax({
        type: "POST",
        url: url,
        data: $("form").serialize(),
        success: function (data) {
            $(replace).html(data);

            onSuccessDelegate();
        }
    });
}