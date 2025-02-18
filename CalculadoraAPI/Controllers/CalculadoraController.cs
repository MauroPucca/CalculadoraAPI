using Microsoft.AspNetCore.Mvc;

namespace CalculadoraAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculadoraController : ControllerBase
{
    [HttpGet("sumar")]
    public ActionResult<int> Sumar(string operacion, [FromQuery] int a, [FromQuery] int b)
    {
        var result = 0;
        switch (operacion)
        {
            case "sumar":
                result = a + b;
                break;
            case "restar":
                result = a - b;
                break;
            case "dividir":
                if (b == 0)
                {
                    return BadRequest("No se puede dividir");
                }
                result = a / b;
                break;
            case "multiplicar":
                result = a * b;
                break;
            default:
                return BadRequest("Operacion invalida");
        }
        var response = new
        {
            a,
            b,
            operacion,
            result,
        };
        return Ok(response);
    }
}        