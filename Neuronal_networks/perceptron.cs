using System;
using System.Collections.Generic;
using System.Ling;
using System.Threading.Tasks;

# Ejemplo de perceptron para implementar la puerta logica AND

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {   // Conjunto de datos para entrenamiento
            int[,] datos = ({1, 1, 1}, {1, 0, 0}, {0, 0, 0});
            // generacion de los valores de peso y umbral
            Random aleatorio = new Random();
            double[] pesos = {aleatorio.NextDOuble(), aleatorio.NextDOuble(), aleatorio.NextDOuble()}
        }
    }
}