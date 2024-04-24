using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
#pragma warning disable CS8604
#pragma warning disable CS8600
#pragma warning disable CS8601

namespace PracticaGrupo4
{
    internal class Program
    {
        static Usuario usuarioLogeado = new Usuario();
        static List<Producto> productos_Maquina = new List<Producto>{};
        public static string nombreUsuario = Environment.UserName;

        static void Main()
        {
            string rutaArchivo = "productos.txt";
            CargarProductosDeArchivo();
            Menu();
        }

        public static void Menu()
        {
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
                    CargarProductosEnArchivo(); //Cargamos los productos en el archivo
                    Menu();
                    break;

                    //Admin
                    case 4:
                    usuarioLogeado = usuarioLogeado.AutenticacionAdmin(usuarioLogeado);
                    usuarioLogeado.Eliminar_Producto_0(productos_Maquina);
                    usuarioLogeado.Anadir_Varios_Productos(productos_Maquina);
                    CargarProductosEnArchivo(); //Cargamos los productos en el archivo
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

        static void CargarProductosEnArchivo()
        {
            if (productos_Maquina.Count > 0) //Si tenemos productos
            {
                File.Create("productos.txt").Close(); //Creamos o sobreescribimos el archivo
                foreach (Producto p in productos_Maquina)
                {
                    p.ToFile(); //Gurdamos cada contenido en el archivo
                }
            }
        }
        private static void CargarProductosDeArchivo()
        {
            if (File.Exists("productos.txt"))
            {
                using (StreamReader sr = new StreamReader("productos.txt"))
                {
                    string linea;

                    while ((linea = sr.ReadLine()) != null)
                    {

                        string[] datos = linea.Split(';');

                        string nombre = datos[0];
                        int cantidad = int.Parse(datos[1]);
                        double precio = double.Parse(datos[2]);
                        string descripcion = datos[3];
                        int id = int.Parse(datos[4]);

                        Producto producto = new Producto(nombre, cantidad, precio, descripcion, id);

                        productos_Maquina.Add(producto);

                    }
                }
                Console.WriteLine("productos cargados correctamente.");
            }
            else
            {
                Console.WriteLine("El archivo de productos no existe. Creando uno nuevo...");
                File.Create("productos.txt").Close();
            }
        }
    }
}














