namespace AromaGrao.Models;

public class Pedido
{
    public double CalcularTotal(double valor, int quantidade)
    {
        return valor * quantidade;
    }

    public double AplicarDesconto(double total)
    {
        if (total >= 100)
        {
            return total * 0.9;
        }
        return total;
    }

    public string StatusPedido(double total)
    {
        if (total < 20)
        {
            return "Pequeno";
        }

        if (total < 100)
        {
            return "Médio";
        }

        return "Grande";
    }
}
