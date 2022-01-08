using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmRestaurante
{
    class StockYDeclaraciones
    {

        public static int[,] productos = new int[9, 9];

        public static String[] TitulosStock = new string[5] { "Nombre", "ID", "Unidades", "CostoUnitario", "PrecioVentaUnitario" };
        public static int[,] stock = new int[10, 4]
        //id unid ,costo,prec.venta
        {
             {1,7,500,1600},
             {2,5,500,1500 },
             {-1,-1,-1,-1},
             {4,8,100,1900},
             {-1,-1,-1,-1},
             {5,15,30,100 },
             {-1,-1,-1,-1},
             {7,9,1300,2200 },
             {8,10,1000,2500 },
             {9,8,950,2400 }

        };
        public static String[] nombre_productos = new string[10]
        {"cutter", "Inflador ", null, "Martillo", null, "Cinta ", null, "Pinza","Destor.Plano", "destor.phil" };

        public static int EspacioLibre;
        public static int Confirmar;
        public static bool TengoEspacio = false;

        //MATRICES AUXILIARES
        public static int[,] AUXstock = new int[10, 4];

        public static String[] AUXnombre_productos = new string[10];

        /// <summary>
        /// Muestra las opciones que esten relacionadas con el stock
        /// </summary>
        public static void SubMenuStock()
        {
            Console.WriteLine(" 1- Mostrar Stock Completo \n 2- Filtrar Stock por nombre \n 3- Modificar Stock \n 4- Cancelar");

            switch (validadores.validador_int(Console.ReadLine(), 1, 5))
            {
                case 1:
                    MostrarStockCompleto();
                    break;

                case 2:
                    ventas.BusquedaPorNombre();
                    break;

                case 3:
                    ModificarStock();
                    break;

                case 4:
                    
                break;
            }

        }

        /// <summary>
        /// Muestra en formato tabla el contendio de la matriz Stock y sus respectivos nombres de productos
        /// </summary>
        public static void MostrarStockCompleto()
        {

            //titulo: Costo,precio,etc
            for (int i = 0; i < TitulosStock.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"|{TitulosStock[i],-20}");
            }

            Console.ForegroundColor = ConsoleColor.White;

            for (int fila = 0; fila < stock.GetLength(0); fila++)
            {
                for (int i = 0; i < nombre_productos.Length; i++)
                {
                    Console.WriteLine();
                    Console.Write($"|{nombre_productos[fila],-20}");

                    for (int col = 0; col < stock.GetLength(1); col++)
                    {
                        Console.Write($"|{stock[fila, col],-20}");
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Modifica la matriz stock
        /// </summary>
        public static void ModificarStock()
        {
            int ID, modificar,confirmar,col=0;
            Console.WriteLine("Busque el producto a modificar:");
            do
            {

            } while (!ventas.BusquedaPorNombre());
            
            // EspacioLibre guardar aca el id?

            Console.WriteLine("\n \n Ingrese el id del producto a modificar");
            ID = validadores.validador_int(Console.ReadLine());
           
            Console.WriteLine("Que quiere modificar? \n1- Nombre  \n2- Unidades \n3- Costo Unitario \n4- Precio de Venta");
            modificar = validadores.validador_int(Console.ReadLine());

            switch (modificar)
            {
                case 1:
                    
                    AUXnombre_productos[ID] = validadores.validador_strings("Ingrese nuevo Nombre");
                break;

                case 2:
                    Console.WriteLine("Ingrese las unidades");
                    AUXstock[ID, 1] = validadores.validador_int(Console.ReadLine());
                    col = 3;
                break;

                case 3:
                    Console.WriteLine("Ingrese el nuevo Costo");
                    AUXstock[ID, 2] = validadores.validador_int(Console.ReadLine());
                    col = 2;
                break;

                case 4:
                    Console.WriteLine("Ingrese el nuevo Precio");
                    AUXstock[ID, 3] = validadores.validador_int(Console.ReadLine());
                    col = 3;
                break;

            }
            Console.WriteLine("Confirmar cambios? \n1- Si \n2- No");
            confirmar = validadores.validador_int(Console.ReadLine(), 1,2);
            if (confirmar==1)
            {
                if (modificar==1)
                {
                    nombre_productos[ID] = AUXnombre_productos[ID];
                }

                else
                {
                    stock[ID, col] = AUXstock[ID, col]; 
                }
            }
            else
            {
                Console.WriteLine("Modificacion Cancelada");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Dentro de este metodo se guarda el algoritmo para cargar el nombre de un producto y rellenar la matriz stock
        /// </summary>
        public static void CargarProductos()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Cargar nuevos productos");
            Console.BackgroundColor = ConsoleColor.Black;
            #region Validador EspacioLibre
            for (int fila = 0; fila < stock.GetLength(0); fila++)
            {
                if (stock[fila, 0] == -1)
                {
                    TengoEspacio = true;
                    EspacioLibre = fila;
                    break;
                }
            }
            #endregion

            if (TengoEspacio == true)
            {
                do
                {
                    if (Confirmar == 3)
                    {
                        break;
                    }
                    AgregarProductosNombre();
                    AgregarAlStock("ingrese el id", 0);
                    AgregarAlStock("ingrese Las unidades", 1);
                    AgregarAlStock("ingrese el costo unitario", 2);
                    AgregarAlStock("ingrese el precio de venta unitario", 3);
                    Confirmar = ConfirmarCargaStock();
                } while (Confirmar == 2);
            }

            if (TengoEspacio == false)
            {
                Console.WriteLine("Almacen lleno,Imposible guardar nuevos productos");

            }
            Console.ReadKey();

        }

        /// <summary>
        /// Muestra la fila que se le pasa por parametro de stock y de su respectivo nombre
        /// </summary>
        /// <param name="fila"></param>
        public static void MostrarFilaStock(int fila)
        {

            for (int i = 0; i < TitulosStock.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"|{TitulosStock[i],-20}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"|{AUXnombre_productos[fila],-20}");//--------------
            for (int i = 0; i < stock.GetLength(1); i++)
            {
                Console.Write($"|{AUXstock[fila, i],-20}");
            }

        }

        /// <summary>
        /// Agrega el nombre del producto a la matriz AuxNombre 
        /// </summary>
        public static void AgregarProductosNombre()
        {
            TengoEspacio = false;
            #region Validador espacios libres
            for (int i = 0; i < nombre_productos.Length; i++)
            {
                if (nombre_productos[i] == null)
                {
                    TengoEspacio = true;
                    EspacioLibre = i;
                    break;
                }
            }
            #endregion

            if (TengoEspacio == true)
            {

                Console.WriteLine();
                Console.WriteLine("Ingrese nombre del producto");
                AUXnombre_productos[EspacioLibre] = Console.ReadLine();
            }
        }

        /// <summary>
        /// Se pasa por parametro un mensaje y numero de columna que se quiere modificar para rellenar la matriz AuxStock
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <param name="columnaStock"></param>
        public static void AgregarAlStock(string Mensaje, int columnaStock)
        {
            Console.Clear();
            #region validadorIDUsado
            int id;
            bool Idrepetido = false;

            if (columnaStock == 0)
            {
                do
                {
                    Idrepetido = false;
                    Console.WriteLine();
                    Console.WriteLine(Mensaje);
                    id = validadores.validador_int(Console.ReadLine());

                    for (int fila = 0; fila < stock.GetLength(0); fila++)
                    {
                        if (stock[fila, 0] == id)//encontro uno igual
                        {
                            Console.WriteLine(stock[fila, 0]);
                            //vendedorLogeado = fila + 1;
                            Idrepetido = true;
                            break;
                        }
                    }
                    if (Idrepetido == true)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Id repetido");
                        Console.BackgroundColor = ConsoleColor.Black;


                    }
                } while (Idrepetido == true);

                if (Idrepetido == false)
                {

                    AUXstock[EspacioLibre, columnaStock] = id;

                    Console.WriteLine("EspacioLibre; " + EspacioLibre);
                }
                return;
            }
            #endregion

            Console.WriteLine(Mensaje);
            AUXstock[EspacioLibre, columnaStock] = validadores.validador_int(Console.ReadLine());
            Console.WriteLine("EspacioLibre; " + EspacioLibre);
        }

        /// <summary>
        ///    Si el usuario Confirma,se carga la informacion de la matriz auxiliar a la matriz definitiva
        /// </summary>
        /// <returns></returns>
        public static int ConfirmarCargaStock()
        {
            MostrarFilaStock(EspacioLibre);

            Console.WriteLine("\n \n Es correcta la informacion? \n 1- Si \n 2- No,Quiero ingresar nuevamente \n 3- Cancelar Carga");
            int CorrectoOno = validadores.validador_int(Console.ReadLine(), 1, 3);

            //modifica producto nombres y agregar al stock
            if (CorrectoOno == 1)
            {
                nombre_productos[EspacioLibre] = AUXnombre_productos[EspacioLibre];
                for (int col = 0; col < stock.GetLength(1); col++)
                {
                    stock[EspacioLibre, col] = AUXstock[EspacioLibre, col];
                }
            }

            return CorrectoOno;
        }
    }

}


