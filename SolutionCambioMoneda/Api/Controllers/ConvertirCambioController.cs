using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConvertirCambioController : ControllerBase
    {


        readonly IConversionTipoCambio _conversionTipoCambio;
        public ConvertirCambioController(IConversionTipoCambio conversionTipoCambio)
        {
            _conversionTipoCambio = conversionTipoCambio;
        }
      

        [HttpGet("ConvertirMoneda")]
        public ActionResult ConvertirMoneda(string origen, string destino, decimal monto)
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                var conversionTipoCambio = _conversionTipoCambio.PostConvertirCambio(origen, destino, monto);
                if (conversionTipoCambio != null)
                {
                    resposonse.data = conversionTipoCambio;
                    resposonse.errormensaje = "";
                    resposonse.error = false;
                }
                else
                {
                    resposonse.data = null;
                    resposonse.errormensaje = "Error No Se Realizo La Conversion";
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
