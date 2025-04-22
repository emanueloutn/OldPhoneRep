// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
namespace ProjectPhone // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Convert("33#"));          // "E"
            Console.WriteLine(Convert("227*#"));       // "B"
            Console.WriteLine(Convert("4433555 555666#")); // "HELLO"
            Console.WriteLine(Convert("4466655520778833082555#")); // "HOLA QUE TAL"
            Console.WriteLine(Convert("8 88777444666*664#")); // "TURING" (asumo que era el objetivo)
        }
        public static string Convert(string input)
        {
            var teclas = new Dictionary<char, string> {
                {'2', "ABC"}, {'3', "DEF"}, {'4', "GHI"}, {'5', "JKL"},
                {'6', "MNO"}, {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"},
                {'0', " "}, {'1', "&'("}
            };

            var resultado = new System.Text.StringBuilder();
            int i = 0;

            while (i < input.Length && input[i] != '#')
            {
                char c = input[i];
                if (c == '*')
                {
                    if (resultado.Length > 0)
                        resultado.Remove(resultado.Length - 1, 1);
                    i++;
                }
                else if (c == ' ')
                {
                    i++;
                }
                else if (teclas.ContainsKey(c))
                {
                    char teclaActual = c;
                    int veces = 0;

                    while (i < input.Length && input[i] == teclaActual)
                    {
                        veces++;
                        i++;
                    }

                    string letras = teclas[teclaActual];
                    resultado.Append(letras[(veces - 1) % letras.Length]);
                }
                else
                {
                    i++;
                }
            }

            return resultado.ToString();
        }
    }
}
