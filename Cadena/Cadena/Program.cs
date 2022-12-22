using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cadena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una frase: ");
            String texto = Console.ReadLine();
            String result = Frase(texto);
            Console.WriteLine(result);
            String result2 = Frase2(texto);
            Console.WriteLine(result2);
            Console.ReadKey();
        }

        static String cadena1;
        private static string Frase(string line)
        {
            string linea = line.ToLower();
            IEnumerable<string> words = GetPalabras(linea);

            var result = words
                        .GroupBy(x => x)
                        .Select(group => new { Word = group.Key, Count = group.Count() })
                        .OrderByDescending(x => x.Count).FirstOrDefault();
            cadena1 = result.Word;
            return "Palabra: " + result.Word + "\t " + " Cuenta " + result.Count;
        }

        private static string Frase2(string line)
        {
            string cadena = "";
            string linea = line.ToLower();
            IEnumerable<string> words = GetPalabras(linea);
            List<string> words2 = new List<string>();

            var cont = 0;

            foreach (var item in words)
            {
                if (!(item.Equals(cadena1)))
                {
                    words2.Add(item);
                }
            }
            foreach (var item in words2)
            {
                var result = words2
                            .GroupBy(x => x)
                            .Select(group => new { Word = group.Key, Count = group.Count() })
                            .OrderByDescending(x => x.Count).FirstOrDefault();
                cadena = result.Word;
                cont = result.Count;
            }

            return "Palabra: " + cadena + "\t " + " Cuenta " + cont;
        }

        private static IEnumerable<string> GetPalabras(string linea)
        {
            return linea.Split(' ', ',', '.', '-', '_', '´').Where(st => !st.Equals(""));
        }
    }
}
