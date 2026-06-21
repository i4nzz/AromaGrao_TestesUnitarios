using AromaGrao.Models;
using Xunit.Abstractions;

namespace AromaGrao.Testes;

public class PedidoCaixaBrancaTests
{

    private readonly ITestOutputHelper _output;

    public PedidoCaixaBrancaTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Theory]
    [InlineData(15, "Pequeno")]
    [InlineData(50, "Médio")]
    [InlineData(150, "Grande")]
    public void StatusPedido_DeveCobrirTodosOsCaminhosIndependentes(double total, string statusEsperado)
    {
        var pedido = new Pedido();

        var resultado = pedido.StatusPedido(total);

        _output.WriteLine($"Entrada: {total} | Esperado: {statusEsperado} | Obtido: {resultado}");

        Assert.Equal(statusEsperado, resultado);
    }
}