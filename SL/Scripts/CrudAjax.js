
$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:63154/api/Empleado/GetAll',
        dataType: 'json',
        success: function (data) {
            $.each(data, function (GetAll, Empleado) {
                $('#tabla-empleados tbody').append(`
                                                <tr>
                                                    <th scope="row">${GetAll + 1}</th
                                                    <td>${Empleado.IdEmpleado}</td>
                                                    <td>${Empleado.Nombre}</td>
                                                    <td>${Empleado.ApellidoPaterno}</td>
                                                    <td>${Empleado.ApellidoMaterno}</td>
                                                    <td>${Empleado.NumeroNomina}</td>
                                                    <td>${Empleado.Estado.IdEstado}</td>
                                                    <td>${Empleado.Estado.EstadoNombre}</td>
                                                    <td><a href="#" onclick="return getbyID(${Empleado.IdEmpleado})">Editar</a> | <a href="#" onclick="Delele(${Empleado.IdEmpleado})">Delete</a></td>
                                                </tr>
                                            `);
            });
        },
        error: function (xhr, status, error) {
            console.error('Error al obtener los datos:', error);
        }
    });
});
