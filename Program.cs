using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLaboratorio
{
    internal class Program
    {
        static string[] codigos={ "AUTO-201", "AUTO-202", "AUTO-203", "AUTO-204", "AUTO-205", "AUTO-206"};
        static string[] modelos = {"SUV Interceptor", "Sedan Executive", "PickUp Titan", "City Hatchback", "Electric EV", "Van Carga"};
        static double[] precioUnitario = {28000.0, 18500.0, 35000.0, 14000.0, 42000.0, 22500.0};
        static int[] cantidadVendida = {2, 4, 1, 5, 1, 3};
        
        //REQ 1 VALIDAR ENTRADA
        static bool ValidarDatos(double precio, int cantidad)
        {
            if (precio > 0 && cantidad > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("ERROR, EL PRECIO O CANTIDAD DEBE SER MAYOR A CERO");
                return false;
            }
        }
        //req 2

        static public void ImprimirMatrizDatos(string[] codigos, double[] precios, int[]cantidades)
        {
            Console.WriteLine("--------------MATRIZ BIDIMENSIONAL DE DATOS (PRECIO Y CANTIDAD)--------------");
            Console.WriteLine("\tFila   |\tCódigo   |\tCol 0 (Precio $) |\tCol 1 (Cantidad)");
            Console.WriteLine("------------------------------------------------------------------------------------");
            for (int i= 0;i <codigos.Length;i++)
            {
                Console.WriteLine($"\t[{i}] | \t\t{codigos[i]} | \t\t{precios[i]} | \t\t{cantidades[i]} ");
            }
        }
        //req 3
        static void MetodoBurbuja(double[] montos, string[]cods, string[]mods)
        {
            int n= montos.Length;
            for (int i= 0; i < n-1; i++)
            {
                for (int j= 0; j < n-1; j++)
                {
                    if (montos[j] < montos[j + 1])
                    {
                        (montos[j], montos[j + 1]) = (montos[j+1], montos[j]);
                        (cods[j], cods[j+1]) = (cods[j+1], cods[j]);
                        (mods[j], mods[j+1]) = (mods[j+1], mods[j]);
                    }
                }
            } 
        }
        //req 4
        static public void BuscarCodigo(string[] codigos, string[] modelos, double[] montos, string codigoBuscado)
        {
            if (string.IsNullOrEmpty(codigoBuscado))
            {
                Console.WriteLine("ERROR, NO ENCONTRADO");
                return ;
            }
            for (int i= 0;i<codigos.Length; i++)
            {
                if (codigos[i]==codigoBuscado)
                {
                    Console.WriteLine($"\nBUSCANDO '{codigoBuscado}': ENCONTRADO");
                    Console.WriteLine($"Modelo: {modelos[i]} | Monto neto: ${montos[i]}");
                    return;
                }
            }
            Console.WriteLine("Código no registrado");
        }
        //req 2
        static void Main(string[] args)
        {
            double[] montoNeto = { 0, 0, 0, 0, 0, 0 }; 
            double totalAcumulado = 0;
            int contadorVentasPremium = 0;

            for (int i = 0 ;i < 6;i++)
            {
                if (ValidarDatos(precioUnitario[i], cantidadVendida[i]))
                {
                    montoNeto[i] = precioUnitario[i] * cantidadVendida[i];
                    totalAcumulado += montoNeto[i];
                    if (montoNeto[i]>50000.0)
                    {
                        contadorVentasPremium++;
                    }
                }
            }
            Console.WriteLine("==============================================================");
            Console.WriteLine("\t\tCONTROL DE VENTAS AUTOMOTRICES");
            Console.WriteLine("==============================================================");
            Console.WriteLine();
            ImprimirMatrizDatos(codigos, precioUnitario, cantidadVendida);
            Console.WriteLine();
            MetodoBurbuja(montoNeto, codigos, modelos);
            Console.WriteLine("-----------REPORTE ORDENADO POR MONTO NETO(DECRECIENTE)----------");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"\t{i + 1}. \tCódigo: {codigos[i]} | \tModelo: {modelos[i]} | \tMonto : $ {montoNeto[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("MÉTRICAS RESUMEN:");
            Console.WriteLine($"* Gran total acumulado: $ {totalAcumulado}");
            Console.WriteLine($"* Ventas Premium (> $50,000):{contadorVentasPremium} transacciones");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("PRUEBA DE BUSQUEDA SECUENCIAL:");
            BuscarCodigo(codigos, modelos, montoNeto, "AUTO-203");
            Console.ReadKey();
        }
    }
}
