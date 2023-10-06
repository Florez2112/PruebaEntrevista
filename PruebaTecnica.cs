using System;
using System.Collections.Generic;
using System.Linq;

class PruebaTecnica
{
    static void Main()
    {
        // Datos de entrada
        //int minCalorias = 15;
        //int pesoMaximo = 10;

        List<Elemento> elementos = new List<Elemento>
        {
            new Elemento("E1", 5, 3),
            new Elemento("E2", 3, 5),
            new Elemento("E3", 5, 2),
            new Elemento("E4", 1, 8),
            new Elemento("E5", 2, 3)
        };

        Console.WriteLine("Ingrese la cantidad de calorias minimas");
        int minCalorias = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el peso maximo");
        int pesoMaximo = int.Parse(Console.ReadLine());

        // Encuentra el conjunto óptimo de elementos
        List<Elemento> conjuntoOptimo = EncontrarElementoOptimo(elementos, minCalorias, pesoMaximo);

        // Imprime los elementos óptimos
        Console.WriteLine("Elementos óptimos:");
        foreach (Elemento elemento in conjuntoOptimo)
        {
            Console.WriteLine($"Nombre: {elemento.Nombre}, Peso: {elemento.Peso}, Calorías: {elemento.Calorias}");
        }

        Console.ReadKey();
    }

    static List<Elemento> EncontrarElementoOptimo(List<Elemento> elementos, int minCalorias, int pesoMaximo)
    {
        // Ordena los elementos por relación calorías/peso en orden descendente
        elementos = elementos.OrderByDescending(e => (double)e.Calorias / e.Peso).ToList();

        List<Elemento> elementoOptimo = new List<Elemento>();
        int caloriasTotales = 0;
        int pesoTotal = 0;

        foreach (Elemento elemento in elementos)
        {
            if (caloriasTotales + elemento.Calorias <= minCalorias && pesoTotal + elemento.Peso <= pesoMaximo)
            {
                elementoOptimo.Add(elemento);
                caloriasTotales += elemento.Calorias;
                pesoTotal += elemento.Peso;
            }
        }

        return elementoOptimo;
    }
}

class Elemento
{
    public string Nombre { get; }
    public int Peso { get; }
    public int Calorias { get; }

    public Elemento(string nombre, int peso, int calorias)
    {
        Nombre = nombre;
        Peso = peso;
        Calorias = calorias;
    }
}
