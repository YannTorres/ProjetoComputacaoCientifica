namespace ToolkitConsole.DecisoresAdicionais;
public class DecisorAdicionais
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("=== Decisores (terminam sempre) ===");
        Console.WriteLine("Opções: ");
        Console.WriteLine("1 - L_fim_b  (termina com 'b')");
        Console.WriteLine("2 - L_mult3_b  (número de 'b' múltiplo de 3)");
        Console.WriteLine("0 - Voltar");

        Console.Write("Escolha: ");
        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.WriteLine("Decisor 1: termina com 'b'?");
                new DecisorAdicionais().ExecutarLogicaDecisor("Decisor 1");
                break;
            case "2":
                Console.WriteLine($"Decisor 2: termina com 'b' multiplo de 3?");
                new DecisorAdicionais().ExecutarLogicaDecisor("Decisor 2");
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                break;
        }
    }

    private void ExecutarLogicaDecisor(string decisor)
    {
        Console.Write("Digite a palavra (contendo apenas 'a' e 'b'): ");
        string palavra = Console.ReadLine() ?? string.Empty;

        if (!PalavraValida(palavra))
        {
            Console.WriteLine("\nErro: A palavra deve conter apenas 'a' ou 'b'.");
            return;
        }

        bool resultado;

        if (decisor == "Decisor 1")
            resultado = DecisorFimB(palavra);
        else
            resultado = DecisorMult3B(palavra);

        if (resultado)
        {
            Console.WriteLine("Resultado: Sim");
        }
        else
        {
            Console.WriteLine("Resultado: Não");
        }
    }

    // Verifica se TODOS os caracteres (c) na palavra contem 'a' ou 'b'
    private bool PalavraValida(string palavra)
    {      
        return palavra.All(c => c == 'a' || c == 'b');
    }

    private bool DecisorFimB(string palavra)
    {
        if(palavra.Length > 0 && palavra[^1] == 'b')
            return true;
        else
            return false;
    }

    private bool DecisorMult3B(string palavra)
    {
        int quantidadeDeB = 0;
        foreach (char simbolo in palavra) if (simbolo == 'b') quantidadeDeB++;

        if (quantidadeDeB % 3 == 0)
            return true;
        else
            return false;
    }
}
