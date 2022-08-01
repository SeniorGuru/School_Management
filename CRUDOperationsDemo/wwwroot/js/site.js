// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
function onDeleteSubject(x) {

    const subject = {
        "Id": x.id,
    };

    if (subject.Id) {
        $.ajax({
            type: 'POST',
            url: '/Subject/Delete',
            data: JSON.stringify(subject),
            success: function (data) {
                window.location.reload();

            },
            error: function (err) {
                alert("Data Error");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    }
}

$(document).ready(function () {
    
    $("#btnCreate").click(function () {
        const student = {
            "FirstName": $("#stdFirst").val(),
            "LastName": $("#stdLast").val(),
            "Email": $("#schoolEmail").val(),
            "Title": "Student",
        };


        if (student.FirstName && student.LastName && student.Email) {
            $.ajax({
                type: 'POST',
                url: '/Student/CreateStudent',
                data: JSON.stringify(student),
                success: function (data) {
                    window.location.reload();

                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
    })

    $("#btnSubjetCreate").click(function () {

        const subject = {
            "Name": $("#subjectName").val(),
            "PeriodCount": $("#periodCount").val()
        };


        if (subject.Name && subject.PeriodCount) {
            $.ajax({
                type: 'POST',
                url: '/Subject/Create',
                data: JSON.stringify(subject),
                success: function (data) {
                    window.location.reload();

                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
    })
   
    $("#btnCreateTeacher").click(function () {
        const student = {
            "FirstName": $("#tFirst").val(),
            "LastName": $("#tLast").val(),
            "Email": $("#tEmail").val(),
            "Title": "teacher",
        };


        if (student.FirstName && student.LastName && student.Email) {
            $.ajax({
                type: 'POST',
                url: '/Student/CreateStudent',
                data: JSON.stringify(student),
                success: function (data) {
                    window.location.reload();

                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
    })

    $("#btnLogin").click(function () {
        const user = {
            "Email": $("#email").val(),
            "Password": $("#password").val(),
        }

        if (user.Email && user.Password) {
            $.ajax({
                type: 'POST',
                url: '/Login/Login',
                data: JSON.stringify(user),
                success: function (data) {
                    if (data == 1) {
                        window.location.href = "/Student/Detail"
                    }
                    if (data == 2) {
                        window.location.href = "/Teacher/Index"
                    }
                    if (data == 3) {
                        window.location.href = "/Admin/Index"
                    }
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
    })

    

    function onDeleteStudent(x) {

    }

    function onDeleteTeacher(x) {

    }

    $(".fa-trash").click(function () {
        const student = {
            "Id":this.id,
            "FirstName": "",
            "LastName": "",
            "Email": "",
            "Title": "Student",
        };

        if (student.Id) {
            $.ajax({
                type: 'POST',
                url: '/Student/Delete',
                data: JSON.stringify(student),
                success: function (data) {
                    window.location.reload();

                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
    })

    $("#imgTeacher").click(function () {
        window.location.href = "/Teacher/Index"
    })

    $("#imgSubject").click(function () {
        window.location.href = "/Subject/index";
    })

    $("#imgInstruction").click(function () {

    })

    $("#imgStudent").click(function () {
        window.location.href = "/Student/Index";
    })

    $("#imgNewStudent").click(function () {

    })

    $("#imgClass").click(function () {

    })
})
