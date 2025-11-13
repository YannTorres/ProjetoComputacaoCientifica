namespace ToolkitConsole.DetectorLoop;
public static class DetectorLoop
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("=== Detector ingênuo de loop ===");

        Console.Write("Estado inicial (inteiro >= 0): ");
        var estadoInicial = Console.ReadLine();
        Console.Write("Módulo M (>1): ");
        var modulo = Console.ReadLine();
        Console.Write("Limite de passos: ");
        var limitePassos = Console.ReadLine();

        if (estadoInicial == null || modulo == null || limitePassos == null)
        {
            Console.WriteLine("Erro: Alguma entrada está vazia.");
            return;
        }

        bool estadoInicialValido = InteiroPositivo(estadoInicial, out int estadoInicialInteiro);
        bool moduloValido = InteiroPositivo(modulo, out int moduloInteiro);
        bool limitePassosValido = InteiroPositivo(limitePassos, out int limiteInteiro);

        if (!estadoInicialValido || !moduloValido || !limitePassosValido || moduloInteiro <= 1)
        {
            Console.WriteLine("Erro: Entradas inválidas. Certifique-se de que o estado inicial e o limite de passos são inteiros >= 0, e o módulo é um inteiro > 1.");
            return;
        }

        HashSet<int> visitados = [];
        int estado = estadoInicialInteiro;
        bool repetiu = false;
        int passo = 0;

        while (passo < limiteInteiro)
        {
            Console.WriteLine($"Passo {passo}: estado={estado}");
            if (!visitados.Add(estado))
            {
                Console.WriteLine("Sinal: estado repetido -> possível laço.");
                repetiu = true;
                break;
            }

            estado = Proximo(estado, moduloInteiro);
            passo++;
        }

        if (!repetiu && passo >= limiteInteiro)
            Console.WriteLine("Execução interrompida por limite de passos.");

        Console.WriteLine("\nReflexão:\n" +
        "- Heurística sinaliza repetição de estado como laço.\n" +
        "- Falsos positivos: ciclos transitórios podem não caracterizar laço infinito do problema original.\n" +
        "- Falsos negativos: laço pode ocorrer após o limite de passos, não sendo detectado.\n");

        Console.WriteLine("Pressione enter para continuar...");
        Console.ReadLine();
    }

    private static bool InteiroPositivo(string? entrada, out int valor)
    {
        valor = 0;
        if (int.TryParse(entrada, out int resultado))
        {
            if (resultado >= 0)
            {
                valor = resultado;
                return true;
            }
        }
        return false;
    }

    private static int Proximo(int estadoAtual, int modulo)
    {
        long proximoEstadoBruto = (long)estadoAtual * 7 + 11;
        return (int)(proximoEstadoBruto % modulo);
    }
}
