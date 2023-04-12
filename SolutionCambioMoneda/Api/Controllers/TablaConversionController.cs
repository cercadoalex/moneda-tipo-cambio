using Api.Entities;
using Api.Entities.Request;
using Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TablaConversionController : ControllerBase
    {
        readonly ITablaConversion _tablaConversion;

        public TablaConversionController(ITablaConversion tablaConversion)
        {
            _tablaConversion = tablaConversion;
        }


        [HttpPost]
        public ActionResult ActualizarTipoCambio(RequestTablaConversion request)
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                var divisas = _tablaConversion.Actualizar(request);
                if (divisas != 0)
                {
                    resposonse.data = divisas;
                    resposonse.errormensaje = "";
                    resposonse.error = false;
                }
                else
                {
                    resposonse.data = null;
                    resposonse.errormensaje = "No existe Divisas";
                    resposonse.error = true;
                }
            }
            catch (Exception ex)
            {
                resposonse.data = null;
                resposonse.errormensaje = ex.Message;
                resposonse.error = true;
            }
            object datos = (object)resposonse;
            return Ok(datos);
        }
    }
}
