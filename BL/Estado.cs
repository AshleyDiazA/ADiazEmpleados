using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static (bool, string, List<ML.Estado>, Exception) GetAll()
        {
            ML.Estado estado = new ML.Estado();
            try
            {
                using(DL.ADiazEmpleadoEntities1 context = new DL.ADiazEmpleadoEntities1())
                {
                    var query = context.GetAllEstado().ToList();
                    if(query.Count > 0)
                    {
                        estado.Estados = new List<ML.Estado>();
                        foreach (var registro in query)
                        {
                            ML.Estado objEstado = new ML.Estado();
                            objEstado.IdEstado = registro.IdEstado;
                            objEstado.EstadoNombre = registro.Estado;

                            estado.Estados.Add(objEstado);
                        }
                    }
                    return (true, null, estado.Estados, null);
                }
            }
            catch (Exception ex) 
            {
                return (false, ex.Message, null, ex);
            }
        }
    }
}
