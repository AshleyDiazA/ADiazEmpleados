using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpPost]
        [Route("api/Empleado/Add")]
        public IHttpActionResult Add([FromBody] ML.Empleado empleado)
        {
            var result = BL.Empleado.Add(empleado);
            if (result.Item1)
            {
                return Ok(result.Item1);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }
        [HttpPut]
        [Route("api/Empleado/Update")]
        public IHttpActionResult Update([FromBody] ML.Empleado empleado)
        {
            var result = BL.Empleado.Update(empleado);
            if (result.Item1)
            {
                return Ok(result);
            }
            else { return BadRequest(result.Item2); }
        }

        [HttpDelete]
        [Route("api/Empleado/Delete")]
        public IHttpActionResult Delete (int idEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.IdEmpleado = idEmpleado;
            var result = BL.Empleado.Delete(idEmpleado);
            if (result.Item1)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }

        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Empleado.GetAll();
            if (result.Item1)
            {
                return Ok(result.Item3);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }

        [HttpGet]
        [Route("api/Empleado/GetById")]
        public IHttpActionResult GetById(int idEmpleado)
        {
            var result = BL.Empleado.GetById(idEmpleado);
            if (result.Item1)
            {
                return Ok(result.Item3);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }
    }
}
