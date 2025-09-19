namespace ToolkitConsole.AvaliadorProposicionalPQR;
public static class AvaliadorProporcionalPQR
{
    // Fórmula 1: (P E Q) -> R  (Implicação)
    static bool Formula1(bool p, bool q, bool r)
    {
        bool p_e_q = p && q;
        return !p_e_q || r;
    }

    // Fórmula 2: (P OU Q) <-> (!R) (Bicondicional)
    static bool Formula2(bool p, bool q, bool r)
    {
        bool p_ou_q = p || q;
        bool nao_r = !r;
        return p_ou_q == nao_r;
    }

    // Verificador de Verdadeiro e Falso
    static bool LerValorLogico(string nomeVariavel)
    {
        while (true)
        {
            Console.Write($"Digite o valor para {nomeVariavel} (V para Verdadeiro, F para Falso): ");
            string? input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "V")
            {
                return true;
            }
            if (input == "F")
            {
                return false;
            }

            Console.WriteLine("Entrada inválida. Por favor, digite 'V' ou 'F'.");
        }
    }

    static string BoolParaString(bool valor)
    {
        return valor ? "Verdadeiro" : "Falso";
    }

    // Tabelela verdades dos possíveis resultados das fórmulas
    static void ImprimirTabelaVerdade(string nomeFormula, Func<bool, bool, bool, bool> formula)
    {
        Console.WriteLine($"\n--- Tabela-Verdade para a Fórmula: {nomeFormula} ---\n");
        Console.WriteLine("|   P   |   Q   |   R   | Resultado |");
        Console.WriteLine("|-------|-------|-------|-----------|");

        for (int i = 0; i < 8; i++)
        {
            bool p = (i & 4) != 0; 
            bool q = (i & 2) != 0; 
            bool r = (i & 1) != 0; 

            bool resultado = formula(p, q, r);

            Console.WriteLine($"| {BoolParaString(p).PadRight(5)} | {BoolParaString(q).PadRight(5)} | {BoolParaString(r).PadRight(5)} | {BoolParaString(resultado).PadRight(9)} |");
        }
        Console.WriteLine("\n");
    }
    public static void Avaliador()
    {
        bool parar = false;
        while (parar == false)
        {
            
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Avaliar a fórmula F1: (P ∧ Q) → R");
            Console.WriteLine("2. Avaliar a fórmula F2: (P ∨ Q) ↔ (¬R)");
            Console.WriteLine("3. Gerar Tabela-Verdade para F1: (P ∧ Q) → R");
            Console.WriteLine("4. Gerar Tabela-Verdade para F2: (P ∨ Q) ↔ (¬R)");
            Console.WriteLine("5. Sair");
            Console.Write("\nOpção: ");

            string? escolha = Console.ReadLine();
            switch (escolha)
            {
                case "1":
                case "2":
                    Console.WriteLine("\n--- Entrada de Valores ---");
                    bool p = LerValorLogico("P");
                    bool q = LerValorLogico("Q");
                    bool r = LerValorLogico("R");

                    bool resultado = (escolha == "1") ? Formula1(p, q, r) : Formula2(p, q, r);
                    string formulaEscolhida = (escolha == "1") ? "(P ∧ Q) → R" : "(P ∨ Q) ↔ (¬R)";

                    Console.WriteLine("\n--- Resultado ---");
                    Console.WriteLine($"Fórmula: {formulaEscolhida}");
                    Console.WriteLine($"Valores: P={BoolParaString(p)}, Q={BoolParaString(q)}, R={BoolParaString(r)}");
                    Console.WriteLine($"O resultado da fórmula é: {BoolParaString(resultado)}\n");
                    break;

                case "3":
                    ImprimirTabelaVerdade("(P ∧ Q) → R", Formula1);
                    break;

                case "4":
                    ImprimirTabelaVerdade("(P ∨ Q) ↔ (¬R)", Formula2);
                    break;

                case "5":
                    Console.WriteLine("Saindo do programa...");
                    parar = true;
                    break;

                default:
                    Console.WriteLine("\nOpção inválida. Por favor, escolha um número de 1 a 5.\n");
                    break;
            }
        }

        Console.Clear();

    }
}
