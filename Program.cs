
using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    // 1. Algoritmo de busqueda lineal
    static int BusquedaLineal(int[] lista, int buscado)
    {
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i] == buscado)
            {
                return i;
            }
        }

        return -1;
    }

    // 2. Medir el tiempo de ejecucion
    static double MedirTiempo(int[] lista)
    {
        Stopwatch reloj = Stopwatch.StartNew();

        // Buscamos 0, pero la lista contiene solamente 1.
        // Esto obliga a recorrer todos los elementos.
        int resultado = BusquedaLineal(lista, 0);

        reloj.Stop();

        // Evita que el resultado quede sin utilizar.
        GC.KeepAlive(resultado);

        return reloj.Elapsed.TotalMilliseconds;
    }

    static void Main()
    {
        const int TIEMPO_OBJETIVO_MS = 3;
        const int MAX_N = 500000;

        int n = 100000;

        Console.WriteLine("CALIBRANDO EL TAMANO INICIAL...");

        // 3. Calibrar n para obtener varios milisegundos
        while (true)
        {
            int[] prueba = Enumerable.Repeat(1, n).ToArray();

            // Calentamiento inicial
            for (int i = 0; i < 5; i++)
            {
                BusquedaLineal(prueba, 0);
            }

            double suma = 0;

            for (int i = 0; i < 3; i++)
            {
                suma += MedirTiempo(prueba);
            }

            double promedio = suma / 3;

            Console.WriteLine(
                $"n = {n:N0} | Tiempo = {promedio:F3} ms"
            );

            if (promedio >= TIEMPO_OBJETIVO_MS || n >= MAX_N)
            {
                break;
            }

            n = Math.Min(n * 2, MAX_N);
        }

        // 4. Crear los tres tamanos de prueba
        int[] tamanos = { n, 4 * n, 16 * n };

        string[] nombres = { "n", "4n", "16n" };

        double[] promedios = new double[3];

        Console.WriteLine("\nCALENTAMIENTO (WARM-UP)");

        int[][] listas = new int[3][];

        for (int i = 0; i < tamanos.Length; i++)
        {
            listas[i] = Enumerable.Repeat(1, tamanos[i]).ToArray();

            // 10 ejecuciones de calentamiento
            for (int j = 0; j < 10; j++)
            {
                BusquedaLineal(listas[i], 0);
            }

            Console.WriteLine(
                $"{nombres[i]}: {tamanos[i]:N0} elementos"
            );
        }

        // 5. Realizar cinco corridas por cada tamano
        const int CORRIDAS = 5;

        Console.WriteLine("\nRESULTADOS DE LAS CINCO CORRIDAS");

        Console.WriteLine(
            "\nTamano\tElementos\tC1\tC2\tC3\tC4\tC5\tPromedio"
        );

        for (int i = 0; i < listas.Length; i++)
        {
            double[] tiempos = new double[CORRIDAS];

            double suma = 0;

            for (int j = 0; j < CORRIDAS; j++)
            {
                tiempos[j] = MedirTiempo(listas[i]);
                suma += tiempos[j];
            }

            promedios[i] = suma / CORRIDAS;

            Console.WriteLine(
                $"{nombres[i]}\t{tamanos[i]:N0}\t" +
                $"{tiempos[0]:F3}\t{tiempos[1]:F3}\t" +
                $"{tiempos[2]:F3}\t{tiempos[3]:F3}\t" +
                $"{tiempos[4]:F3}\t{promedios[i]:F3} ms"
            );
        }

        // 6. Calcular los ratios
        double ratio1 = promedios[1] / promedios[0];
        double ratio2 = promedios[2] / promedios[1];
        double ratio3 = promedios[2] / promedios[0];

        Console.WriteLine("\nCOMPARACION DE RATIOS");

        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Comparacion\t\tRatio\tEsperado");
        Console.WriteLine("-------------------------------------");

        Console.WriteLine(
            $"T(4n) / T(n)\t\t{ratio1:F3}\t4"
        );

        Console.WriteLine(
            $"T(16n) / T(4n)\t\t{ratio2:F3}\t4"
        );

        Console.WriteLine(
            $"T(16n) / T(n)\t\t{ratio3:F3}\t16"
        );

        Console.WriteLine("-------------------------------------");

        Console.WriteLine("\nPRUEBA FINALIZADA.");
        Console.ReadKey();
    }
}
