namespace ToolkitConsole.VerificarAlfabetoCadeia;
public static class VerificarAlfabetoCadeia
{
    private static readonly HashSet<char> _alfabeto = new HashSet<char>("ab");
    public static string Verificar(string entrada)
    {
        if (string.IsNullOrWhiteSpace(entrada))
        {
            return "Entrada inválida. A entrada não pode ser nula ou vazia.";
        }

        int primeiroEspaco = entrada.IndexOf(' ');

        string simboloString;
        string cadeia;

        if (primeiroEspaco == -1) 
        {
            if (entrada.Length == 1)
            {
                simboloString = entrada;
                cadeia = string.Empty; 
            }
            else
            {
                return "Formato de entrada inválido. Use \"símbolo + espaço + cadeia\" ou apenas um símbolo.";
            }
        }
        else
        {
            simboloString = entrada.Substring(0, primeiroEspaco);
            cadeia = entrada.Substring(primeiroEspaco).TrimStart();
        }

        if (simboloString.Length != 1)
        {
            return $"Entrada de símbolo inválida: '{simboloString}'. Por favor, insira apenas um caractere.";
        }

        char simbolo = simboloString[0];
        bool simboloValido = _alfabeto.Contains(simbolo);
        string resultadoSimbolo = simboloValido
            ? $"O símbolo '{simbolo}' é VÁLIDO (pertence a Σ)."
            : $"O símbolo '{simbolo}' é INVÁLIDO (não pertence a Σ).";

        bool cadeiaValida = true;
        char? simboloInvalidoNaCadeia = null;

        if (!string.IsNullOrEmpty(cadeia))
        {
            foreach (char c in cadeia)
            {
                if (!_alfabeto.Contains(c))
                {
                    cadeiaValida = false;
                    simboloInvalidoNaCadeia = c;
                    break;
                }
            }
        }

        string resultadoCadeia = cadeiaValida
            ? $"A cadeia '{cadeia}' é VÁLIDA (todos os símbolos pertencem a Σ*)."
            : $"A cadeia '{cadeia}' é INVÁLIDA (o símbolo '{simboloInvalidoNaCadeia}' não pertence ao alfabeto).";

        return $"{resultadoSimbolo}\n{resultadoCadeia}";
    }
}

