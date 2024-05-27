using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static (bool, string, Exception) Add (ML.Empleado empleado)
        {
            try
            {
                using(DL.ADiazEmpleadoEntities1 context = new DL.ADiazEmpleadoEntities1())
                {
                    var query = context.AddEmpleado(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.NumeroNomina, empleado.Estado.IdEstado);
                    if(query > 0)
                    {
                        return (true, null, null);
                    }
                    else { return (false, "No Add", null); }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public static (bool, string, Exception) Update (ML.Empleado empleado)
        {
            try
            {
                using (DL.ADiazEmpleadoEntities1 context = new DL.ADiazEmpleadoEntities1())
                {
                    var query = context.UpdateEmpleado(empleado.IdEmpleado, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno,
                        empleado.NumeroNomina, empleado.Estado.IdEstado);
                    if(query > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, "No Updating", null);
                    }
                }
            }
            catch(Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }

        public static (bool, string, Exception) Delete (int idEmpleado)
        {
            try
            {
                using(DL.ADiazEmpleadoEntities1 context = new DL.ADiazEmpleadoEntities1())
                {
                    int query = context.DeleteEmpleado(idEmpleado);
                    if(query > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return(false, "No Delete", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }

        public static (bool, string, ML.Empleado, Exception) GetById(int idEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            try
            {
                using (DL.ADiazEmpleadoEntities1 context =  new DL.ADiazEmpleadoEntities1())
                {
                    var query =  context.GetByIdEmpleado(idEmpleado).Single();
                    if(query != null)
                    {
                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.NumeroNomina = query.NumeroNomina;
                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = query.IdEstado;
                        empleado.Estado.EstadoNombre = query.Estado;
                    }
                    return (true, null, empleado, null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        } 
        public static (bool, string, List<ML.Empleado>, Exception) GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            try
            {
                using (DL.ADiazEmpleadoEntities1 context = new DL.ADiazEmpleadoEntities1 ())
                {
                    var registros = context.GetAllEmpleado().ToList ();

                    if(registros.Count > 0)
                    {
                        empleado.Empleados = new List<ML.Empleado>();
                        foreach (var registro in registros)
                        {
                            ML.Empleado objEmpleado = new ML.Empleado ();
                            objEmpleado.IdEmpleado = registro.IdEmpleado;
                            objEmpleado.Nombre = registro.Nombre;
                            objEmpleado.ApellidoPaterno = registro.ApellidoPaterno;
                            objEmpleado.ApellidoMaterno = registro.ApellidoMaterno;
                            objEmpleado.NumeroNomina = registro.NumeroNomina;
                            objEmpleado.Estado = new ML.Estado();
                            objEmpleado.Estado.IdEstado = registro.IdEstado;
                            objEmpleado.Estado.EstadoNombre = registro.Estado;

                            empleado.Empleados.Add (objEmpleado);
                        }
                    }
                    return (true, null, empleado.Empleados, null);
                }
            }
            catch (Exception ex) 
            {
                return (false, ex.Message, null, ex);
            }
        }
    }
}
