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
    public static void Classificador(string textojson)
    {

        List<Problema> problemas;
        try
        {
            problemas = JsonSerializer.Deserialize<List<Problema>>(textojson) ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao ler JSON: " + ex.Message);
            return;
        }

        if (problemas.Count == 0)
            Console.WriteLine("Erro ao ler JSON");

        int acertos = 0, erros = 0;

        foreach (var p in problemas)
        {
            Console.WriteLine($"\nProblema: {p.Descricao}");
            Console.Write("Classificação (T/I/N): ");
            string? resposta = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(resposta))
                Console.WriteLine("Resposta vazia!");

            if (resposta == p.Gabarito.ToUpper())
            {
                Console.WriteLine("Acertou!");
                acertos++;
            }
            else
            {
                Console.WriteLine($"Errou! Correto seria: {p.Gabarito}");
                erros++;
            }
        }

        Console.WriteLine("===== RESUMO =====");
        Console.WriteLine($"Total de problemas: {problemas.Count}");
        Console.WriteLine($"Acertos: {acertos}");
        Console.WriteLine($"Erros: {erros}");
    }
}

