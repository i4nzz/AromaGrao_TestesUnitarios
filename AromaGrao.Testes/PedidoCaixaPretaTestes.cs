using AromaGrao.Models;
using Xunit.Abstractions;

namespace AromaGrao.Testes;

public class PedidoCaixaPretaTests
{

    private readonly ITestOutputHelper _output;

    public PedidoCaixaPretaTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Theory]
    [InlineData(19.99, 19.99)]
    [InlineData(20.00, 20.00)]
    [InlineData(99.99, 99.99)]
    [InlineData(100.00, 90.00)]
    public void AplicarDesconto_ValorLimite_DeveRetornarValorCorreto(double total, double esperado)
    {
        var pedido = new Pedido();
        var resultado = pedido.AplicarDesconto(total);

        _output.WriteLine($"Entrada: {total} | Esperado: {esperado} | Obtido: {resultado}");

        Assert.Equal(esperado, resultado, precision: 2);
    }
}
