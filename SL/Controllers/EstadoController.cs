using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class EstadoController : ApiController
    {
        [HttpGet]
        [Route("api/Estado/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Estado.GetAll();
            if (result.Item1)
            {
                return Ok(result.Item3);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }
    }
}
