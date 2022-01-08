using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmRestaurante
{


    public class LogInVendedores
    {
        public static string[,] Vendedores = new string[4, 2]
        {
        {"Lucas068","123" },
        {"Facundo15","123" },
        {"Miguel89","123" },
        {"Juan76","123" },
        };

        public static string usuario, contraseña;
        public static int vendedorLogeado;
        public static bool LoginCorrecto = false;
        public static void Login()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Por favor ingrese Su Usuario: Lucas068 \n");
                usuario = Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Por favor ingrese Su contraseña: 123");
                contraseña = Console.ReadLine();

                for (int fila = 0; fila < Vendedores.GetLength(0); fila++)
                {
                    for (int col = 0; col < Vendedores.GetLength(1); col++)
                    {
                        if (Vendedores[fila, 0] == usuario)//encontro el usuario
                        {
                            if (Vendedores[fila, 1] == contraseña)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("**Logeado con exito**");
                                Console.ForegroundColor = ConsoleColor.White;
                                vendedorLogeado = fila + 1;
                                LoginCorrecto = true;
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                }

                if (LoginCorrecto == false)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**El usuario y/o la contraseña son incorrectos**\n Presione enter para continuar");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
            } while (LoginCorrecto == false);

        }

    }
}
