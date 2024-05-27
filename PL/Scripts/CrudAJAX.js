$(document).ready(function () {
    GetAll();
});
function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:63154/api/Empleado/GetAll',
        dataType: 'json',
        success: function (data) {
            var reload = '';
            $.each(data, function (GetAll, Empleado) {
                reload += '<tr>';
                reload += '<td>' + Empleado.NumeroNomina + '</td>';
                reload += '<td>' + Empleado.Nombre + '</td>';
                reload += '<td>' + Empleado.ApellidoPaterno + '</td>';
                reload += '<td>' + Empleado.ApellidoMaterno + '</td>';
                reload += '<td>' + Empleado.Estado.EstadoNombre + '</td>';
                reload += '<td><a class="btn btn-warning" href="#" onclick="return getbyID(' + Empleado.IdEmpleado + ')">Editar</a> | <a class="btn btn-danger" href="#" onclick="Delele(' + Empleado.IdEmpleado + ')">Borrar</a></td>';
                reload += '</tr>';
            });
            $('#tabla-empleados tbody').html(reload);
        },
        error: function (xhr, status, error) {
            console.error('Error al obtener los datos:', error);
        }
    });
};
function Add() {
    var empObj = {
        IdEmpleado: null,
        Nombre: $("#Nombre").val(),
        ApellidoPaterno: $("#ApellidoPaterno").val(),
        ApellidoMaterno: $("#ApellidoMaterno").val(),
        NumeroNomina: $("#NumeroNomina").val(),
        Estado: {
            IdEstado: parseInt($("#IdEstado").val())
        }
    };
    $.ajax({
        url: "http://localhost:63154/api/Empleado/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            console.log("Empleado agregado exitosamente.");
            GetAll();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            console.log("No agregado" + errormessage);
            alert(errormessage.responseText);
        }
    });
}

function Update() {
    var empObj = {
        IdEmpleado: ($("#IdEmpleado").val()),
        Nombre: ($("#Nombre").val()),
        ApellidoPaterno: ($("#ApellidoPaterno").val()),
        ApellidoMaterno: ($("#ApellidoMaterno").val()),
        NumeroNomina: ($("#NumeroNomina").val()),
        Estado: {
            IdEstado: parseInt($("#IdEstado").val())
        }
    };
    $.ajax({
        url: "http://localhost:63154/api/Empleado/Update",
        data: JSON.stringify(empObj),
        type: "PUT",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            GetAll();
            $('#myModal').modal('hide');
            $("#IdEmpleado").val("");
            $("#Nombre").val("");
            $("#ApellidoPaterno").val("");
            $("#ApellidoMaterno").val("");
            $("#NumeroNomina").val("");
            $("#IdEstado").val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delele(IdEmpleado) {
    var borrar = confirm("¿Seguro que quieres eliminar?");
    if (borrar) {
        $.ajax({
            url: "http://localhost:63154/api/Empleado/Delete?idEmpleado=" + IdEmpleado,
            type: "DELETE",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                GetAll();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function getbyID(IdEmpleado) {
    $('#Nombre').css('border-color', 'lightgrey');
    $('#ApellidoPaterno').css('border-color', 'lightgrey');
    $('#ApellidoMaterno').css('border-color', 'lightgrey');
    $('#NumeroNomina').css('border-color', 'lightgrey');
    $('#IdEstado').css('border-color', 'lightgrey');
    $.ajax({
        url: "http://localhost:63154/api/Empleado/GetById?idEmpleado=" + IdEmpleado,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#IdEmpleado').val(result.IdEmpleado);
            $('#Nombre').val(result.Nombre);
            $('#ApellidoPaterno').val(result.ApellidoPaterno);
            $('#ApellidoMaterno').val(result.ApellidoMaterno);
            $('#NumeroNomina').val(result.NumeroNomina);
            $('#IdEstado').val(result.Estado.IdEstado)

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:63154/api/Estado/GetAll",
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Selecciona un estado</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].IdEstado + '">' + data[i].EstadoNombre + '</option>';
            }
            $("#IdEstado").html(s);
        }
    });
});

function clearTextBox() {
    $('#IdEmpleado').val("");
    $('#Nombre').val("");
    $('#ApellidoPaterno').val("");
    $('#ApellidoMaterno').val("");
    $('#NumeroNomina').val("");
    $('#IdEstado').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Nombre').css('border-color', 'lightgrey');
    $('#ApellidoPaterno').css('border-color', 'lightgrey');
    $('#ApellidoMaterno').css('border-color', 'lightgrey');
    $('#NumeroNomina').css('border-color', 'lightgrey');
    $('#IdEstado').css('border-color', 'lightgrey');
}