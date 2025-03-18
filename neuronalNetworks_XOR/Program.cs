using System;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] datos = { { 0, 0, 0 }, { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };

            Random aleatorio = new Random();
            double[] pesos1 = { aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble() };
            double[] pesos2 = { aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble() }; 
            double[] pesosSalida = { aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble() };

            double tasaAprendizaje = 0.1;
            bool aprendizaje = true;
            int epocas = 0;
            int salidaInt = 0;

            while (aprendizaje && epocas < 10000) 
            {
                aprendizaje = false;
                for (int i = 0; i < 4; i++)
                {
                    int x1 = datos[i, 0];
                    int x2 = datos[i, 1];
                    int salidaEsperada = datos[i, 2];

                    double neta1 = x1 * pesos1[0] + x2 * pesos1[1] + pesos1[2];
                    double salida1 = neta1 > 0 ? 1 : 0;

                    double neta2 = x1 * pesos2[0] + x2 * pesos2[1] + pesos2[2];
                    double salida2 = neta2 > 0 ? 1 : 0;

                    double netaSalida = salida1 * pesosSalida[0] + salida2 * pesosSalida[1] + pesosSalida[2];
                    salidaInt = netaSalida > 0 ? 1 : 0;

                    if (salidaInt != salidaEsperada)
                    {
                        double error = salidaEsperada - salidaInt;

                        pesosSalida[0] += tasaAprendizaje * error * salida1;
                        pesosSalida[1] += tasaAprendizaje * error * salida2;
                        pesosSalida[2] += tasaAprendizaje * error;

                        pesos1[0] += tasaAprendizaje * error * x1;
                        pesos1[1] += tasaAprendizaje * error * x2;
                        pesos1[2] += tasaAprendizaje * error;

                        pesos2[0] += tasaAprendizaje * error * x1;
                        pesos2[1] += tasaAprendizaje * error * x2;
                        pesos2[2] += tasaAprendizaje * error;

                        aprendizaje = true;
                    }
                }
                epocas++;
            }

            Console.WriteLine("Resultados finales:");
            for (int i = 0; i < 4; i++)
            {
                int x1 = datos[i, 0];
                int x2 = datos[i, 1];

                double neta1 = x1 * pesos1[0] + x2 * pesos1[1] + pesos1[2];
                double salida1 = neta1 > 0 ? 1 : 0;

                double neta2 = x1 * pesos2[0] + x2 * pesos2[1] + pesos2[2];
                double salida2 = neta2 > 0 ? 1 : 0;

                double netaSalida = salida1 * pesosSalida[0] + salida2 * pesosSalida[1] + pesosSalida[2];
                salidaInt = netaSalida > 0 ? 1 : 0;

                Console.WriteLine($"Entradas: {x1} XOR {x2} = {datos[i, 2]} Perceptrón: {salidaInt}");
            }
            Console.WriteLine($"Épocas necesarias: {epocas}");
            Console.ReadLine();
        }
    }
}
