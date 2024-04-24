using System.Security.Cryptography.X509Certificates;

namespace PracticaGrupo4
{
    internal class Program
    {
        static Usuario usuarioLogeado = new Usuario();
        static List<Producto> productos_Maquina = new List<Producto>{};
        public static string nombreUsuario = Environment.UserName;

        static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            //Lee el nombre del usuario
            //string nombreUsuario = Environment.UserName;
            int respuestaMenu;

            try
            {
                do
                {
                    Console.Clear();
                    Portada.Cambiar_Color();
                    Portada.introducir_Portada();
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("+----------UFV VENDING MACHINE----------+");
                    Console.WriteLine("Elige una opción:");
                    Console.WriteLine("(1) Comprar productos");
                    Console.WriteLine("(2) Mirar información de un producto");
                    Console.WriteLine("(3) Recargar un producto (Admin)");
                    Console.WriteLine("(4) Recargar todos los productos (Admin)");
                    Console.WriteLine("(5) SALIR");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n</{nombreUsuario}/>>> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    respuestaMenu = int.Parse(Console.ReadKey().KeyChar.ToString());   //Convierte de 'System.ConsoleKeyInfo' a 'Char' a 'String' a 'Int'

                } while (respuestaMenu < 1 || respuestaMenu > 5);

                switch (respuestaMenu)
                {
                    case 1:
                    usuarioLogeado.Eliminar_Producto_0(productos_Maquina);
                    usuarioLogeado.Comprar_Producto(productos_Maquina);
                    Menu();
                    break;

                    case 2:
                    usuarioLogeado.Eliminar_Producto_0(productos_Maquina);
                    MostarInfoProd();   //Muestra la info de todos los productos 
                    Menu();
                    break;

                    //Admin
                    case 3:
                    usuarioLogeado = usuarioLogeado.AutenticacionAdmin(usuarioLogeado);    //Settea al usuario como "Admin" o "Cliente"
                    usuarioLogeado.Eliminar_Producto_0(productos_Maquina);
                    usuarioLogeado.Anadir_Producto(productos_Maquina);
                    Menu();
                    break;

                    //Admin
                    case 4:
                    usuarioLogeado = usuarioLogeado.AutenticacionAdmin(usuarioLogeado);
                    usuarioLogeado.Eliminar_Producto_0(productos_Maquina);
                    usuarioLogeado.Anadir_Varios_Productos(productos_Maquina);
                    Menu();
                    break;

                    default:
                    Console.WriteLine("\nSaliendo...");
                    break;
                }
            }
            
            
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"\nError: {ex.Message}");
                Console.WriteLine("Regresando al Menú...");
                Console.WriteLine("No presiones ninguna tecla...");
                Thread.Sleep(2000);
                Menu();
            }            
        }

        static void MostarInfoProd()
        {
            Console.Clear();
            Console.WriteLine("\n<<< Información de los productos >>> ");

            foreach(Producto producto in productos_Maquina)
            {
                Console.WriteLine($"\n{producto.Mostrar_Info_Completa()}");   //Para cada producto mostrará la información
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }

    }
}














