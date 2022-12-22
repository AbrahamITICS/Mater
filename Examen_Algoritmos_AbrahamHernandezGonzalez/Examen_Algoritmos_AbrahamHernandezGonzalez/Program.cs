using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Algoritmos_AbrahamHernandezGonzalez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[3];
            int[] b = new int[3];
            int puntoAlice = 0, puntoBob = 0;
            int j = 0, k = 0;

            // alice
            Console.WriteLine("Ingrese las 3 Categorias de Promedio de Alice");
            do
            {
                Console.Write("Categoria [" + (j + 1) + "]: ");
                a[j] = int.Parse(Console.ReadLine());

                if (a[j] >= 1 && a[j] <= 100)
                {
                    j++;
                }
                else
                {
                    Console.WriteLine("\nIngrese la calificacion [1 - 100]");
                }
            } while (j < 3);

            // bob
            Console.WriteLine("\n\nIngrese las 3 Categorias de Promedio de Bob");
            do
            {
                Console.Write("Categoria [" + (k + 1) + "]: ");
                b[k] = int.Parse(Console.ReadLine());

                if (b[k] >= 1 && b[k] <= 100)
                {
                    k++;
                }
                else
                {
                    Console.WriteLine("\nIngrese la calificacion [1 - 100]");
                }
            } while (k < 3);

            // Calificaicones de alices
            Console.WriteLine("\n\nCalificaciones \n\t\tALICE: \t BOB: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("Categoria " + (i + 1) + ":\t " + a[i] + "\t" + b[i]);
            }
            // total de puntos
            Console.WriteLine("\nPuntos totales");
            for (int i = 0; i < 3; i++)
            {
                if (a[i] > b[i])
                {
                    puntoAlice++;
                }
                else if (a[i] < b[i])
                {
                    puntoBob++;
                }
            }
            Console.WriteLine("Alice: " + puntoAlice + "\nBob: " + puntoBob);
            Console.ReadKey();
            //Console.Clear();
        }
    }
}
