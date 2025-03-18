using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Ejemplo de perceptron para implementar la puerta logica AND

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {   // Conjunto de datos para entrenamiento
            int[,] datos = {{1, 1, 1}, {1, 0, 0}, {0, 1, 0}, {0, 0, 0}};
            // Generacion de los valores de peso y umbral
            Random aleatorio = new Random();
            double[] pesos = {aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble()};
            // etapa de aprendizaje
            bool aprendizaje = true;
            int salidaInt = 0;
            int epocas = 0;
            while(aprendizaje)
            {
                aprendizaje = false;
                for (int i = 0; i < 4; i++)
                {
                    double salidaDoub = datos[i, 0] * pesos[0] + datos[i, 1] * pesos[1] + pesos[2];
                    if (salidaDoub > 0) salidaDoub = 1; else salidaInt = 0;
                    if (salidaInt != datos[i, 2])
                    {
                        pesos[0] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        pesos[1] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        pesos[2] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        aprendizaje = true;
                    }
                    epocas++;
                }
                // Finaliza el aprendizaje
                // Verificacion de resultados
                for (int i = 0; i < 4; i ++)
                {
                    double salidaDoub = datos[i, 0]* pesos[0] + datos[i, 0] * pesos[1] + pesos[2];
                    if (salidaDoub > 0) salidaInt = 1; else salidaInt =0;
                    Console.WriteLine("Entradas: " + datos [i, 0].ToString() + " AND " + datos[i, 1].ToString() + " = " + datos[i, 2].ToString() + " Perceptron: " + salidaInt.ToString());
                }
                Console.WriteLine("Epocas: " + epocas.ToString());
                Console.WriteLine("Pesos utiles: p0= " + pesos[0].ToString() + " p1= " + pesos[1].ToString() + " Umbral = " + pesos[2].ToString());
                Console.ReadLine();
            }
        }
    }
}