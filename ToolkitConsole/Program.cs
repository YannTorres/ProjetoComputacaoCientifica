using ToolkitConsole.AvaliadorProposicionalPQR;
using ToolkitConsole.ClassificadorTIN;
using ToolkitConsole.DecisoresAdicionais;
using ToolkitConsole.DecisorTerminaComB;
using ToolkitConsole.DetectorLoop;
using ToolkitConsole.ProblemaXInstancia;
using ToolkitConsole.ReconhecedorLinguagens;
using ToolkitConsole.ReconheciveisNaoTermina;
using ToolkitConsole.SimuladorAFD;
using ToolkitConsole.VerificarAlfabetoCadeia;

bool loop = true;

while (loop)
{
    ExibirMenu();
    Console.Write("Digite uma opção: ");
    string opcaoDigitada = Console.ReadLine() ?? "";

    switch (opcaoDigitada)
    {
        case "1":
            Console.Write("Digite um símbolo e depois uma cadeia: ");
            string texto = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(texto))
                Console.Write("Texto inválido tente novamente.");

            Console.WriteLine();
            Console.WriteLine(VerificarAlfabetoCadeia.Verificar(texto!));
            Console.WriteLine();
            break;
        case "2":
            Console.WriteLine("Altere o Json dentro da pasta ClassificadorTIN se quiser alterar os problemas");
            string caminho = Path.Combine(AppContext.BaseDirectory, "ClassificadorTIN/classificador.json");
            string arquivojson = File.ReadAllText(caminho);

            Console.WriteLine();
            ClassificadorTIN.Classificador(arquivojson);
            Console.WriteLine();
            break;
        case "3":
            Console.Write("Digite uma cadeia: ");
            string cadeia = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(cadeia))
                Console.Write("Texto inválido tente novamente.");

            Console.WriteLine();
            Console.WriteLine(DecisorTerminaComB.Decisor(cadeia!));
            Console.WriteLine();
            break;
        case "4":
            Console.WriteLine();
            AvaliadorProporcionalPQR.Avaliador();
            Console.WriteLine();
            break;
        case "5":
            Console.WriteLine();
            ReconhecedorLinguagens.Executar();
            Console.WriteLine();
            break;
        case "6":
            Console.WriteLine("Altere o Json dentro da pasta ProblemaXInstancia se quiser alterar os problemas");
            string caminhoProblemaXInstancia = Path.Combine(AppContext.BaseDirectory, "ProblemaXInstancia/ProblemaXInstancia.json");
            string arquivojsonProblemaXInstancia = File.ReadAllText(caminhoProblemaXInstancia);

            ProblemaXInstancia.Executar(arquivojsonProblemaXInstancia);
            Console.WriteLine();
            break;
        case "7":
            Console.WriteLine();
            DecisorAdicionais.Executar();
            Console.WriteLine();
            break;
        case "8":
            Console.WriteLine();
            ReconheciveisNaoTermina.Executar();
            Console.WriteLine();
            break;
        case "9":
            Console.WriteLine();
            DetectorLoop.Executar();
            Console.WriteLine();
            break;
        case "10":
            Console.WriteLine();
            SimuladorAFD.Executar();
            Console.WriteLine();
            break;
        case "0":
            loop = false;
            break;
        default:
            Console.WriteLine();
            Console.WriteLine("Número inválido tente novamente");
            Console.WriteLine();
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