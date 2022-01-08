using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmRestaurante
{
    class Iniciar
    {

        public static void IniciarPrograma()

        {
            int opcionSwitch;


            LogInVendedores.Login();

            do
            {

                #region MostrarOpciones
                Console.Clear();
                Console.WriteLine("\n"
                            + "\nIngrese el Numero de opcion:"
                            + "\n "
                            + "\n 1- Cargar nuevos ingresos de productos"
                            + "\n 2- Stock"
                            + "\n 3- cargar ventas"
                            + "\n 4- ver ventas Del dia"
                            + "\n 5- Salir del programa");
                #endregion 

                opcionSwitch = validadores.validador_int(Console.ReadLine(), 1, 5);  //envio el numero y el min y max del menu

                switch (opcionSwitch)
                {
                    case 1:
                        StockYDeclaraciones.CargarProductos();
                        Console.ReadKey();
                        break;
                    #region otro
                    case 2:
                        Console.WriteLine("stock");

                        StockYDeclaraciones.SubMenuStock();
                        Console.ReadKey();
                        break;


                    case 3:
                        Console.WriteLine("Cargar ventas");
                        ventas.RealizarUnaNuevaVenta();
                        Console.ReadKey();
                        break;


                    case 4:
                        Console.WriteLine("Ver ventas");
                        ventas.VentasDelDia();
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("salir del programa");
                        break;
                        #endregion

                }

            } while (opcionSwitch != 5);

        }

    }
}
