namespace ToolkitConsole.DecisorTerminaComB;
public static class DecisorTerminaComB
{
    public static string Decisor(string entrada)
    {
        bool terminaComB = entrada.EndsWith("b", StringComparison.OrdinalIgnoreCase);
        var ehOuNao = "";

        if (entrada == "")
        {
            ehOuNao = "NAO";
        }
        if (terminaComB)
        {
            ehOuNao = "SIM";
        }
        else
        {
            ehOuNao = "NAO";
        }

        Console.WriteLine(ehOuNao);
        return("\nExecução finalizada");
    }
}
