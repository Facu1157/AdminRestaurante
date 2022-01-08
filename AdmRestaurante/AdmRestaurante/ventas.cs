using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmRestaurante
{
    class ventas
    {  
        public static String[] TitulosFactura = new string[3] { "Nombre", "Unidades", "Total" };
       
        public static double[,] TotalVentas = new double[10, 2]
        {
         {0,0},
         {0,0},
         {0,0},
         {0,0},
         {0,0},
         {0,0},
         {0,0},
         {0,0},
         {0,0},
         {0,0},
        };
       
   /// <summary>
   /// Realiza una nueva venta segun stock,la suma a la matriz TotalVentas y descuenta del stock
   /// </summary>
        public static void RealizarUnaNuevaVenta()
        {
            int idVender, unidades = 0, subtotal, total = 0, algoMas, EspacioLibre;
            bool encontrado, repetir = false, stockSuficiente = true;

            do
            {
                subtotal = 0;
                encontrado = BusquedaPorNombre();
                Console.WriteLine();

                if (encontrado == true)
                {
                    Console.WriteLine("Ingrese el id del producto que quiere vender");
                    idVender = validadores.validador_int(Console.ReadLine());

                   
                    if (StockYDeclaraciones.stock[idVender, 1] < 0)
                    {
                        Console.WriteLine("No hay stock suficiente para la venta--------");
                    }

                    else
                    {
                        #region Validador de stock

                        do
                        {
                            stockSuficiente = true;
                            Console.WriteLine("Ingrese unidades de la venta:");
                            unidades = validadores.validador_int(Console.ReadLine());
                            if (unidades > StockYDeclaraciones.stock[idVender, 1])
                            {
                                Console.WriteLine("No hay stock suficiente para la venta,intente nuevamente");
                                stockSuficiente = false;
                                Console.ReadKey();
                                Console.Clear();
                            }
                        } while (stockSuficiente == false);
                        #endregion

                        subtotal = subtotal + StockYDeclaraciones.stock[idVender, 3] * unidades;
                        
                        for (int i = 0; i < TitulosFactura.Length; i++)//--------------------
                        {
                            Console.Write($"|{TitulosFactura[i],-20}");
                        }
                        Console.WriteLine();
                        Console.WriteLine($"|{StockYDeclaraciones.nombre_productos[idVender],-20}|{unidades,-20}|{subtotal,-20}");
                        Console.WriteLine("¿Quiere vender algo mas?" + "\n 1-Agregar otra venta" + "\n 2-Finalizar Venta");
                        algoMas = validadores.validador_int(Console.ReadLine(), 1, 2);

                        TotalVentas[idVender, 0] = TotalVentas[idVender, 0] + unidades;
                        TotalVentas[idVender, 1] = TotalVentas[idVender, 1] + subtotal;

                        if (algoMas == 1)
                        {
                            repetir = true;
                        }

                        else
                        {
                            //a unidades de stock le resto int unidades
                            repetir = false;
                        }
                    }
                    StockYDeclaraciones.stock[idVender, 1] = StockYDeclaraciones.stock[idVender, 1] - unidades;
                }

                else
                {
                    repetir = true;
                }
            } while (repetir == true);
        }

        /// <summary>
        /// Muestra cuanto se vendio de cada producto y el total general
        /// </summary>
        public static void VentasDelDia()
        {
            double totalRecaudado=0;
            //titulo: Costo,precio,etc
            for (int i = 0; i < TitulosFactura.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write($"|{TitulosFactura[i],-20}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
           

            for (int fila = 0; fila < TotalVentas.GetLength(0); fila++)
            {
                for (int i = 0; i < StockYDeclaraciones.nombre_productos.Length; i++)
                {
                    Console.WriteLine();
                    Console.Write($"|{StockYDeclaraciones.nombre_productos[fila],-20}");

                    for (int col = 0; col < TotalVentas.GetLength(1); col++)
                    {
                        Console.Write($"|{TotalVentas[fila, col],-20}");
                    }
                    break;
                }
            }


            for (int i = 0; i < TotalVentas.GetLength(0); i++)
            {
                totalRecaudado = totalRecaudado + TotalVentas[i,1];
            }
            Console.Write("\n "+ "\n"+"Total= ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("$"+totalRecaudado);
            Console.ForegroundColor = ConsoleColor.White;

        }
        
        /// <summary>
        /// Hace una busqueda parcial por nombre y muestra las filas encontradas de la matriz stock y su respectivo nombre
        /// </summary>
        /// <returns></returns>
        public static bool BusquedaPorNombre()
        {
            string nombreProducto;
            int Posicion = 0;
            bool encontrado = false;
            nombreProducto = validadores.validador_strings("Nombre del producto:");
            Console.Clear();

            #region Mostrar Resultados
            for (int titulo = 0; titulo < StockYDeclaraciones.TitulosStock.Length; titulo++)
            {
                Console.Write($"|{StockYDeclaraciones.TitulosStock[titulo],-20}");
            }


            for (int i = 0; i < StockYDeclaraciones.nombre_productos.Length; i++)
            {

                if (StockYDeclaraciones.nombre_productos[i] != null)
                {
                    if (StockYDeclaraciones.nombre_productos[i].ToUpper().Trim().Contains(nombreProducto.ToUpper().Trim()))
                    {
                        //en las posiciones en las que hay un null roimpe
                        Posicion = i;
                        encontrado = true;

                        Console.WriteLine();
                        Console.Write($"|{StockYDeclaraciones.nombre_productos[Posicion],-20}");

                        for (int col = 0; col < StockYDeclaraciones.stock.GetLength(1); col++)
                        {
                            Console.Write($"|{StockYDeclaraciones.stock[Posicion, col],-20}");
                        }
                    }
                }

            }
            if (encontrado == false)
            {
                Console.WriteLine("\n");
                Console.WriteLine("** No se encontraron resultados**");
            }
            #endregion

            return encontrado;
        }


    }


}







