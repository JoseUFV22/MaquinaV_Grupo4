using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
#pragma warning disable CS8603

namespace PracticaGrupo4
{
    public class Usuario
    {
        private string contrasena = "contrasena123";

        public virtual void Test(){}

        public Usuario AutenticacionAdmin(Usuario usuario)
        {
            //Si el usuario no es Admin o Cliente (porque es un nuevo usuario)
            if (usuario is not Admin && usuario is not Cliente)
            {
                string? contrasenaIntento;

                Console.WriteLine("Introduce la contraseña de administrador: ");
                contrasenaIntento = Console.ReadLine();

                if (contrasena == contrasenaIntento)
                {
                    Console.WriteLine("[Autenticado]");
                    return new Admin();                  //Se identifica al usuario como Admin
                }

                else
                {
                    Console.WriteLine("Contraseña Incorrecta...");
                    return new Cliente();                //Se identifica al usuario como Cliente
                }
            }

            //Si el usuario ya es Admin, no hace falta volver a autenticarse
            else if (usuario is Admin)
            {
                Console.WriteLine("Bienvenido Administrador");
                return usuario;
            }

            //Si el usuario es identificado como cliente, se le niega el acceso
            else if (usuario is Cliente)
            {
                Console.WriteLine("No tienes los privilegios suficientes...");
                return usuario;
            }

            return null;

        }
    }
}
