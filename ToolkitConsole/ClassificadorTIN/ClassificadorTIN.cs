using System.Text.Json;
using System.Text.Json.Serialization;

namespace ToolkitConsole.ClassificadorTIN;
public static class ClassificadorTIN
{
    public record Problema
    {
        [JsonPropertyName("descricao")]
        public string Descricao { get; init; } = "";

        [JsonPropertyName("gabarito")]
        public string Gabarito { get; init; } = "";
    }
    public static string Classificador(string textojson)
    {
        List<Problema>? problemas;
        try
        {
            problemas = JsonSerializer.Deserialize<List<Problema>>(textojson);
            if (problemas == null)
            {
                return "Erro: O JSON está vazio ou mal formatado.";
            }
        }
        catch (JsonException)
        {
            return "Erro: O texto inserido não é um JSON válido.";
        }

        int acertos = 0;
        int erros = 0;
        int totalProblemas = problemas.Count;

        if (totalProblemas == 0)
        {
            return "O JSON não contém nenhum problema para classificar.";
        }

        int problemaAtual = 1;
        foreach (var problema in problemas)
        {
            Console.WriteLine($"\n----- Problema {problemaAtual}/{totalProblemas} -----");
            Console.WriteLine($"Descrição: {problema.Descricao}");

            string? respostaUsuario = "";
            while (respostaUsuario != "T" && respostaUsuario != "I" && respostaUsuario != "N")
            {
                Console.Write("Sua classificação (T/I/N): ");
                respostaUsuario = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (respostaUsuario != "T" && respostaUsuario != "I" && respostaUsuario != "N")
                {
                    Console.WriteLine("Opção inválida. Por favor, digite T, I ou N.");
                }
            }

            if (respostaUsuario == problema.Gabarito.ToUpper())
            {
                Console.WriteLine("Resposta correta! 👍");
                acertos++;
            }
            else
            {
                Console.WriteLine($"Resposta incorreta. 👎 A resposta certa era: {problema.Gabarito.ToUpper()}");
                erros++;
            }
            problemaAtual++;
        }

        Console.WriteLine("\n=============================================");
        Console.WriteLine("               Resumo Final");
        Console.WriteLine("=============================================");
        Console.WriteLine($"Total de problemas: {totalProblemas}");
        Console.WriteLine($"Acertos: {acertos} ✅");
        Console.WriteLine($"Erros: {erros} ❌");

        if (totalProblemas > 0)
        {
            double percentual = ((double)acertos / totalProblemas) * 100;
            Console.WriteLine($"Percentual de acertos: {percentual:F2}%");
        }
    }
}

