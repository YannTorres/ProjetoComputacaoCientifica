using ToolkitConsole.ClassificadorTIN;
using ToolkitConsole.VerificarAlfabetoCadeia;

var loop = true;

while (loop)
{
    ExibirMenu();
    Console.Write("Digite uma opção: ");
    var opcaoDigitada = Console.ReadLine();

    switch (opcaoDigitada)
    {
        case "1":
            Console.Write("Digite um símbolo e depois uma cadeia: ");
            var texto = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(texto))
                Console.Write("Texto inválido tente novamente.");

            Console.WriteLine(VerificarAlfabetoCadeia.Verificar(texto!));
            break;
        case "2":
            Console.Write(@"Digite uma lista de itens no formato Json, no seguinte formato:
            [ { ""descricao"": ""Encontrar o maior elemento em uma lista desordenada."", ""gabarito"": ""T"" } ]");
            Console.WriteLine();
            Console.Write("Digite o Json:");

            var textojson = Console.ReadLine() ?? "";
            ClassificadorTIN.Classificador(textojson);
            break;
        case "3":
            break;
        case "4":
            break;
        case "5":
            break;
        case "0":
            loop = false;
            break;
        default:
            Console.WriteLine("Número inválido tente novamente");
            break;
    }
}

void ExibirMenu()
{
    Console.WriteLine("Projeto Toolkit (versao simples)");
    Console.WriteLine("1 - Verificar alfabeto e cadeia (Sigma={a,b})");
    Console.WriteLine("2 - Classificador T/I/N por JSON");
    Console.WriteLine("3 - Decisor: termina com 'b'?");
    Console.WriteLine("4 - Avaliador proposicional (P,Q,R)");
    Console.WriteLine("5 - Reconhecedor: L_par_a e a b*");
    Console.WriteLine("6 - Problema x instancia por JSON");
    Console.WriteLine("7 - Decisores: L_fim_b e L_mult3_b");
    Console.WriteLine("8 - Reconhecedor que pode nao terminar (a^ib ^ i)");
    Console.WriteLine("9 - Detector ingenuo de loop");
    Console.WriteLine("10 - Simulador AFD simples (termina com 'b')");
    Console.WriteLine("0 - Sair");
}