using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
#pragma warning disable CS8603


namespace PracticaGrupo4
{
    public class Usuario
    {
        //Atributos
        private string contrasena = "123";


        //Constructores
        public Usuario(){}


        //Metodos
        public virtual void Añadir_Producto(List<Producto> productos_maquina){}

        public Usuario AutenticacionAdmin(Usuario usuario)
        {
            //Si el usuario no es Admin o Cliente (porque es un nuevo usuario)
            if (usuario is not Admin && usuario is not Cliente)
            {
                string? contrasenaIntento;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nIntroduce la contraseña de administrador: ");
                Console.ForegroundColor = ConsoleColor.White;
                contrasenaIntento = Console.ReadLine();

                if (contrasena == contrasenaIntento)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[Autenticado]");
                    Console.ForegroundColor = ConsoleColor.White;
                    return new Admin();                  //Se identifica al usuario como Admin
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Contraseña Incorrecta...");
                    Console.WriteLine("Regresando al Menú...");
                    Thread.Sleep(2000);
                    return new Cliente();                //Se identifica al usuario como Cliente
                }
            }

            //Si el usuario ya es Admin, no hace falta volver a autenticarse
            else if (usuario is Admin)
            {
                Console.Clear();
                Console.WriteLine("\nBienvenido Administrador");
                return usuario;
            }

            //Si el usuario es identificado como cliente, se le niega el acceso
            else if (usuario is Cliente)
            {
                Console.Clear();
                Console.WriteLine("No tienes los privilegios suficientes...");
                Console.WriteLine("Regresando al Menú...");
                Thread.Sleep(2000);
                return usuario;
            }

            return null;

        }
    }
}
