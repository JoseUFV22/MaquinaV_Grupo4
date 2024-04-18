namespace PracticaGrupo4
{
    class Program
    {
        static Usuario usuarioLogeado = new Usuario();

        static void Main()
        {
           
        }

        public static void Menu()
        {
            //Lee el nombre del usuario
            string nombreUsuario = Environment.UserName;
            int respuestaMenu;

            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("+----------UFV VENDING MACHINE----------+");
                    Console.WriteLine("Elige una opción:");
                    Console.WriteLine("(1) Comprar productos");
                    Console.WriteLine("(2) Mirar información de un producto");
                    Console.WriteLine("(3) Recargar un producto (Admin)");
                    Console.WriteLine("(4) Recargar todos los productos (Admin)");
                    Console.WriteLine("(5) SALIR");
                    Console.Write($"\n</{nombreUsuario}/>>> ");
                    respuestaMenu = int.Parse(Console.ReadKey().KeyChar.ToString());   //Convierte de 'System.ConsoleKeyInfo' a 'Char' a 'String' a 'Int'

                } while (respuestaMenu < 1 || respuestaMenu > 5);

                switch (respuestaMenu)
                {
                    case 1:
                    
                    break;

                    case 2:
                    break;

                    //Admin
                    case 3:
                    usuarioLogeado = usuarioLogeado.AutenticacionAdmin(usuarioLogeado);    //Settea al usuario como "Admin" o "Cliente"
                    usuarioLogeado.Test();
                    Menu();
                    break;

                    //Admin
                    case 4:
                    usuarioLogeado.AutenticacionAdmin(usuarioLogeado);

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
                Thread.Sleep(2000);
                Menu();
            }
            
        }

    }
}














