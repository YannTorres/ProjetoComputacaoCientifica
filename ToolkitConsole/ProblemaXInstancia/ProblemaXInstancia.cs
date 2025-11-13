using System.Text.Json;
using System.Text.Json.Serialization;
using static ToolkitConsole.ClassificadorTIN.ClassificadorTIN;

namespace ToolkitConsole.ProblemaXInstancia;
public class ProblemaXInstancia
{
    public record ProblemaXInstanciaJson
    {
        [JsonPropertyName("frase")]
        public string Frase { get; init; } = "";

        [JsonPropertyName("resultado")]
        public string Resultado { get; init; } = "";
    }
    public static void Executar(string textoJson)
    {
        Console.WriteLine();
        Console.WriteLine("=== PROBLEMA X INSTÂNCIA ===");
        List<ProblemaXInstanciaJson> problemas;
        try
        {
            problemas = JsonSerializer.Deserialize<List<ProblemaXInstanciaJson>>(textoJson) ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao ler JSON: " + ex.Message);
            return;
        }

        if (problemas.Count == 0)
            Console.WriteLine("Erro ao ler JSON, não foram encontrados problemas");

        int acertos = 0, erros = 0;

        foreach (var problema in problemas)
        {
            Console.WriteLine($"\nFrase: {problema.Frase}");
            Console.Write("É um Problema ou é uma Instancia? (Digite P/I): ");
            string? resposta = Console.ReadLine()?.Trim().ToUpper();
            if (string.IsNullOrEmpty(resposta))
            {
                Console.WriteLine("Resposta vazia!");
                continue;
            }
            else if (resposta == problema.Resultado.ToUpper())
            {
                Console.WriteLine("Acertou!");
                acertos++;
            }
            else
            {
                Console.WriteLine($"Errou! Correto seria: {problema.Resultado}");
                erros++;
            }
        }
        Console.WriteLine();
        Console.WriteLine("===== RESUMO =====");
        Console.WriteLine($"Total de frases: {problemas.Count}");
        Console.WriteLine($"Acertos: {acertos}");
        Console.WriteLine($"Erros: {erros}");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadLine();
    }
}
