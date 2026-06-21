using AromaGrao.Models;
using Microsoft.AspNetCore.Mvc;

namespace AromaGrao.Controllers;

[ApiController]
[Route("pedido")]
public class PedidoController : ControllerBase
{
    [HttpPost("calcular")]
    public IActionResult Calcular([FromBody] PedidoRequest request)
    {
        var pedido = new Pedido();
        var total = pedido.CalcularTotal(request.Valor, request.Quantidade);

        return Ok(new { total });
    }
}

