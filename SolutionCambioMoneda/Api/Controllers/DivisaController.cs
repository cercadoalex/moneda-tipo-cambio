using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DivisaController : ControllerBase
    {
        readonly IDivisa _divisa;
        public DivisaController(IDivisa divisa)
        {
            _divisa = divisa;
        }

        [HttpGet("GetDivisa")]

        public ActionResult<List<Divisa>> GetDivisa()
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                var divisas = _divisa.GetAllDivisa();
                if (divisas != null)
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
