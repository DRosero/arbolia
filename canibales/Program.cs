using System;
using System.Collections.Generic;
using System.Text;

namespace canibales
{
    class Program
    {
        static void Main(string[] args)
        {
            nodo.Nodos = 0;
            nodo.Ngen = 1;
            nodo.n_hijo = 0;
            int canibales, misioneros;
            Console.WriteLine("\ncantidad de caniblaes\n");
            canibales = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\ncantidad de misioneros\n");
            misioneros=Convert.ToInt32(Console.ReadLine());
            nodo raiz = new nodo(canibales, misioneros, 0, 0, false);
            nodo actual = raiz;
            actual.setcalificacion(1000);
            nodo siguiente = new nodo();
            Boolean fin=false;
            do
            {
                actual = actual.checa_nodos();
                if (actual.getcanibales() == 0 && actual.getmisioneros() == 0)
                {
                    fin = true;
                }
                else
                actual.opciones();
            } while (!fin);
            actual.camino.Add(actual);
            //Console.WriteLine(actual.camino);
            actual.imprimir(actual);
            Console.ReadKey();
        }
    }
}
