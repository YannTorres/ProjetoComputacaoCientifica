using System;
using System.Text.Json;

namespace ToolkitConsole.ReconhecedorLinguagens
{
    public class ReconhecedorLinguagens
    {
        private class Resultado
        {
            public string Palavra { get; set; } = string.Empty;
            public string Linguagem { get; set; } = string.Empty;
            public bool Aceita { get; set; }
        }

        public static void Executar()
        {
            Console.WriteLine("=== RECONHECEDOR DE LINGUAGENS ===");
            Console.WriteLine("1 - L_par_a  (número par de 'a')");
            Console.WriteLine("2 - L = { w | w = a b* }  (começa com 'a' seguido de zero ou mais 'b')");
            Console.Write("Opção: ");
            string? opcaoRaw = Console.ReadLine();
            string opcao = (opcaoRaw ?? string.Empty).Trim();

            if (opcao != "1" && opcao != "2")
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            Console.Write("Digite a palavra: ");
            string palavra = (Console.ReadLine() ?? string.Empty).Trim();

            bool aceita;
            string nomeLinguagem;

            if (opcao == "1")
            {
                aceita = PertenceLParA(palavra);
                nomeLinguagem = "L_par_a";
            }
            else
            {
                if (!ValidarAlfabeto(palavra))
                {
                    Console.WriteLine("Entrada inválida: para L = {a b*} use apenas os símbolos 'a' e 'b'.");
                    return;
                }

                aceita = PertenceLAbEstrela(palavra);
                nomeLinguagem = "L = { w | w = a b* }";
            }

            Resultado resultado = new Resultado
            {
                Palavra = palavra,
                Linguagem = nomeLinguagem,
                Aceita = aceita
            };

            string json = JsonSerializer.Serialize(resultado, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);
            Console.WriteLine(aceita ? "ACEITA" : "REJEITA");
            Console.WriteLine();
        }

        private static bool ValidarAlfabeto(string palavra)
        {
            foreach (char c in palavra)
            {
                if (c != 'a' && c != 'b') return false;
            }

            return true;
        }

        private static bool PertenceLParA(string palavra)
        {
            int contadorA = 0;
            foreach (char c in palavra)
            {
                if (c == 'a') contadorA++;
            }
            return (contadorA % 2) == 0;
        }

        private static bool PertenceLAbEstrela(string palavra)
        {
            if (string.IsNullOrEmpty(palavra)) return false;
            if (palavra[0] != 'a') return false;

            for (int i = 1; i < palavra.Length; i++)
            {
                if (palavra[i] != 'b') return false;
            }
            return true;
        }
    }
}
