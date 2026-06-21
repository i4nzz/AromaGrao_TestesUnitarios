using AromaGrao.Models;
using Xunit.Abstractions;

namespace AromaGrao.Testes;

public class PedidoAdHocTests
{
    private readonly ITestOutputHelper _output;

    public PedidoAdHocTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void CalcularTotal_QuantidadeNegativa_ComportamentoInesperado()
    {
        var pedido = new Pedido();
        var resultado = pedido.CalcularTotal(valor: -10, quantidade: -5);

        _output.WriteLine($"Entrada: valor=-10, quantidade=-5 | Obtido: {resultado}");

        // Sem validação no código, -10 * -5 = 50 (positivo!)
        // Isso é um bug: pedido com valores negativos "se anulam" e parece válido
        Assert.Equal(50, resultado);
    }

    [Fact]
    public void CalcularTotal_QuantidadeMuitoGrande_NaoEstoura()
    {
        var pedido = new Pedido();
        var resultado = pedido.CalcularTotal(valor: 10, quantidade: 999999999);

        _output.WriteLine($"Entrada: valor=10, quantidade=999999999 | Obtido: {resultado}");

        Assert.Equal(9999999990, resultado);
    }

    [Fact]
    public void CalcularTotal_ValorNegativoQuantidadePositiva_RetornaTotalNegativo()
    {
        var pedido = new Pedido();
        var resultado = pedido.CalcularTotal(valor: -10, quantidade: 5);

        _output.WriteLine($"Entrada: valor=-10, quantidade=5 | Obtido: {resultado}");

        // Bug: o sistema aceita preço negativo sem reclamar
        Assert.Equal(-50, resultado);
    }
}