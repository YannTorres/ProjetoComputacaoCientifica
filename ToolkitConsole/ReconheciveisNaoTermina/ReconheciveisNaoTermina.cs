namespace ToolkitConsole.ReconheciveisNaoTermina;
public static class ReconheciveisNaoTermina
{
    private const long LimiteDePassos = 10000000;
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("=== Eeconhecedor que pode não terminar ===\n\n" +
                          "Linguagem Alvo (L): Palavras em Σ={a,b} que contêm 'aa' como subpalavra.");
        Console.Write("Digite uma cadeia: ");
        var valorDigitado = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(valorDigitado))
        {
            Console.WriteLine("Erro: A cadeia não pode ser vazia.");
            return;
        }

        bool cadeiaValida = PalavraValida(valorDigitado);

        if (!cadeiaValida)
        {
            Console.WriteLine("Erro: A cadeia deve conter apenas os símbolos 'a' e 'b'.");
            return;
        }

        string resposta = Reconhecer_ContemAA(valorDigitado);

        Console.WriteLine($"{resposta}");

        Console.WriteLine("Pressione enter para continuar...");
        Console.ReadLine();
    }

    private static bool PalavraValida(string palavra)
    {
        return palavra.All(c => c == 'a' || c == 'b');
    }

    private static string Reconhecer_ContemAA(string palavra)
    {
        long passoAtual = 0;

        Console.WriteLine("[LOG] Fase 1: Procurando por 'aa'...");
        for (int i = 0; i < palavra.Length - 1; i++)
        {
            passoAtual++; 

            if (palavra[i] == 'a' && palavra[i + 1] == 'a')
            {
                Console.WriteLine($"[LOG] 'aa' encontrado na posição {i}.");
                return "Sim (Aceito)";
            }

            if (passoAtual > LimiteDePassos)
            {
                Console.WriteLine("\n[LOG] ABORTADO: Limite de passos atingido na Fase 1.");
                return "Não (Abortado por Limite)";
            }
        }

        Console.WriteLine("[LOG] 'aa' não encontrado. Palavra não pertence a L.");
        Console.WriteLine("[LOG] Fase 2: Entrando em loop infinito (simulação)...");

        while (true)
        {
            passoAtual++; 

            if (passoAtual > LimiteDePassos)
            {
                Console.WriteLine($"\n[LOG] ABORTADO: Limite de {LimiteDePassos:N0} passos atingido na Fase 2.");
                return "Não (Abortado por Limite)";
            }


            if (passoAtual % 10000000 == 0)
            {
                Console.WriteLine($"[LOG] ... preso no loop... passo {passoAtual:N0}");
            }
        }
    }
}
