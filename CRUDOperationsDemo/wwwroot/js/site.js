// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
window.localStorage.setItem("type", 1);

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

function onPresent() {
    window.localStorage.setItem("type", 1);
}

function onLate() {
    window.localStorage.setItem("type", 2);
}

function onInfration() {
    window.localStorage.setItem("type", 3);
}

function onAbsent() {
    window.localStorage.setItem("type", 4);
}

function onStudentAbsense(x) {

    var inputId = x.id + "100";
    const absense = {
        "StudentId": x.id,
        "Date": Date.now(),
        "AbsenseType": window.localStorage.getItem("type"),
        "Note": $("#" + inputId).val(),
        "Teacher": $("#absenseTeacher").text(),
        "Subject": $("#absenseSubject").text()
    };

    console.log(absense);
    if (absense.StudentId && absense.Date && absense.AbsenseType && absense.Note) {
        $.ajax({
            type: 'POST',
            url: '/StudentAbsense/CreateAbsense',
            data: JSON.stringify(absense),
            success: function (data) {
            },
            error: function (err) {
                alert("Data Error");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    }
    else {
        alert("InputData error");
    }
}
function onDeleteEnroll(x) {

    const enroll = {
        "Id": x.id,
    };

    if (enroll.Id) {
        alert(enroll.Id);
        $.ajax({
            type: 'POST',
            url: '/Enrollment/Delete',
            data: JSON.stringify(enroll),
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
        else {
            alert("Input Error");
        }
    })

    $("#btnBack").click(function () {
        window.location.href = "/";
    })

    $("#btnCreateNewSemester").click(function () {

        const semester = {
            "Name": $("#semesterName").val(),
            "FromDate": $("#semesterFromDate").val(),
            "EndDate": $("#semesterEndDate").val(),
        };


        if (semester.Name && semester.FromDate && semester.EndDate) {
            $.ajax({
                type: 'POST',
                url: '/Semester/Create',
                data: JSON.stringify(semester),
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
        else {
            alert("Input Error");
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
        else {
            alert("Input Error");
        }
    })
   
    $("#btnCreateTeacher").click(function () {

        const teacher = {
            "FirstName": $("#tFirstName").val(),
            "LastName": $("#tLastName").val(),
            "Email": $("#tEmail").val(),
            "Title": "teacher",
        };

        if (teacher.FirstName && teacher.LastName && teacher.Email) {
            $.ajax({
                type: 'POST',
                url: '/Teacher/Create',
                data: JSON.stringify(teacher),
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
        else {
            alert("Input Error");
        }
    })

    $("#btnCreateEnroll").click(function ()
    {
        const enroll = {
            "Teacher": $("#eTeacher").val(),
            "Subject": $("#eSubject").val(),
            "Student": $("#eStudent").val(),
        };

        if (enroll.Teacher && enroll.Subject && enroll.Student) {
            $.ajax({
                type: 'POST',
                url: '/Enrollment/Create',
                data: JSON.stringify(enroll),
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
        else {
            alert("Input Error");
        }
    })
    //$("#btnLogin").click(function () {
    //    const user = {
    //        "Email": $("#email").val(),
    //        "Password": $("#password").val(),
    //    }

    //    if (user.Email && user.Password) {
    //        $.ajax({
    //            type: 'POST',
    //            url: '/Login/Login',
    //            data: JSON.stringify(user),
    //            success: function (data) {
    //                if (data == 1) {
    //                    window.location.href = "/Student/Detail"
    //                }
    //                if (data == 2) {
    //                    window.location.href = "/Teacher/Index"
    //                }
    //                if (data == 3) {
    //                    window.location.href = "/Admin/Index"
    //                }
    //            },
    //            error: function (err) {
    //                alert("Data Error");
    //            },
    //            contentType: "application/json",
    //            dataType: 'json'
    //        });
    //    }
    //})

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
        window.location.href = "/Teacher/Edit"
    })

    $("#imgSubject").click(function () {
        window.location.href = "/Subject/Index";
    })

    $("#imgInstruction").click(function () {
        window.location.href = "/Instructor/Index"
    })

    $("#imgNewStudent").click(function () {
        window.location.href = "/Student/Index";
    })

    $("#imgClass").click(function () {
        window.location.href = "/Enrollment/Index";
    })

    $("#recordLog").click(function () {
        window.location.href = "/RecordLog/Index";
    })

    $("#studentAccess").click(function () {

        window.location.href = "/Admin/Access";
    })

    $("#newSemester").click(function () {
        window.location.href = "/Semester/Index";
    })

})
