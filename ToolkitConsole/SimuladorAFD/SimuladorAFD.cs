namespace ToolkitConsole.SimuladorAFD;
public class SimuladorAFD
{
    /// <summary>
    /// δ: A função de transição, representada por um dicionário aninhado.
    /// Formato: TabelaDeTransicao[EstadoAtual][Simbolo] -> ProximoEstado
    /// </summary>
    private readonly Dictionary<string, Dictionary<char, string>> _transicoes;

    /// <summary>
    /// q0: O estado inicial.
    /// </summary>
    private readonly string _estadoInicial;

    /// <summary>
    /// F: O conjunto de estados de aceitação (finais).
    /// </summary>
    private readonly HashSet<string> _estadosFinais;

    public SimuladorAFD()
    {
        _estadoInicial = "q0";

        _estadosFinais = new HashSet<string> { "q2" };

        _transicoes = new Dictionary<string, Dictionary<char, string>>
        {
            { "q0", new Dictionary<char, string> {
                { 'a', "q0" },  // Se vir 'a', continua em q0
                { 'b', "q1" }   // Se vir 'b', vai para q1
            }},
            
            { "q1", new Dictionary<char, string> {
                { 'a', "q2" },  // Se vir 'a', completa "ba" e vai para q2 
                { 'b', "q1" }   // Se vir outro 'b', continua em q1
            }},
            
            { "q2", new Dictionary<char, string> {
                { 'a', "q0" },  // Se vir 'a', volta a q0
                { 'b', "q1" }   // Se vir 'b', agora termina em "b", vai para q1
            }}
        };
    }

    public static void Executar()
    {
        Console.WriteLine("=== Simulador de AFD (Σ={a,b} que terminam com 'ba') ===");
        Console.Write("Digite a palavra a ser processada: ");
        var palavra = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(palavra))
        {
            Console.WriteLine("Erro: A palavra não pode ser vazia.");
            return;
        }

        bool cadeiaValida = PalavraValida(palavra);

        if (!cadeiaValida)
        {
            Console.WriteLine($"Erro: A palavra deve conter apenas os símbolos 'a' e 'b'.");
            return;
        }

        var simulador = new SimuladorAFD();

        string estadoAtual = simulador._estadoInicial;
        Console.WriteLine($"Iniciando no estado: {estadoAtual}");
        Console.WriteLine("===================================");

        foreach (char simbolo in palavra)
        {
            string proximoEstado = simulador._transicoes[estadoAtual][simbolo];

            Console.Write($"... Estado: {estadoAtual}, Consumindo: '{simbolo}' -> ");

            estadoAtual = proximoEstado;

            Console.WriteLine($"Novo estado: {estadoAtual}");
        }

        Console.WriteLine("===================================");

        if (simulador._estadosFinais.Contains(estadoAtual))
        {
            Console.WriteLine($"Processamento concluído.");
            Console.WriteLine($"Estado final: {estadoAtual}. Palavra ACEITA.");
        }
        else
        {
            Console.WriteLine($"Processamento concluído.");
            Console.WriteLine($"Estado final: {estadoAtual}. Palavra REJEITADA.");
        }
    }

    private static bool PalavraValida(string palavra)
    {
        return palavra.All(c => c == 'a' || c == 'b');
    }
}
