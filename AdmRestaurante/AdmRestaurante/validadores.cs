using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmRestaurante
{
    class validadores
    {
        public static bool TengoEspacio;
        public static int EspacioLibre;

        /// <summary>
        /// Valida que el dato ingresado por parametros sea un numero y no supere el maximo ni sea inferior al minimo
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="min_opc"></param>
        /// <param name="max_opc"></param>
        /// <returns></returns>
        public static int validador_int(String numero, int min_opc, int max_opc)
        {
            bool sepuede_conver;
            int num_validado;

            do
            {

                sepuede_conver = int.TryParse(numero, out num_validado);

                if (!sepuede_conver || num_validado < min_opc || num_validado > max_opc) //error
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrecto,Vuelva a ingresar");
                    Console.BackgroundColor = ConsoleColor.Black;
                    
                    numero = Console.ReadLine();

                }
                Console.Clear();
            } while (!sepuede_conver || num_validado < min_opc || num_validado > max_opc);

            return num_validado;

        }

        /// <summary>
        /// Valida que el dato ingresado por parametro sea un numero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static int validador_int(String numero)
        {
            bool sepuede_conver;
            int num_validado;

            do
            {

                sepuede_conver = int.TryParse(numero, out num_validado);

                if (!sepuede_conver) //error
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrecto,Vuelva a ingresar");
                    Console.BackgroundColor = ConsoleColor.Black;
                    
                    numero = Console.ReadLine();

                }
                Console.Clear();
            } while (!sepuede_conver);

            return num_validado;

        }

        /// <summary>
        /// Valida que el string ingresado no contenga espacios ni sea un espacio en blanco
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static string validador_strings(string mensaje)
        {

            bool error;
            string palabra;

            Console.WriteLine(mensaje);
             palabra= Console.ReadLine();

            do
            {
                error = false;
                if (string.IsNullOrWhiteSpace(palabra))
                {
                    error = true;

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un texto valido");
                    Console.BackgroundColor = ConsoleColor.Black;

                    palabra=Console.ReadLine();
                }
            } while (error==true);
            return palabra;
        }

    }
}
