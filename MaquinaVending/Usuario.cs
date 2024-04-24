using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
#pragma warning disable CS8603
#pragma warning disable CS8604
#pragma warning disable CS8600

namespace PracticaGrupo4
{
    public class Usuario
    {
        //Atributos
        private string contrasena = "123";


        //Constructores
        public Usuario(){}


        //Metodos
        public virtual void Añadir_Producto(List<Producto> productos_Maquina){}
        public virtual void Añadir_Varios_Productos(List<Producto> productos_Maquina){}


        private void Otro_Producto(List<Producto> productos_Maquina)
        {
            Console.Clear();
            Console.WriteLine("Quieres comprar otro producto? [1]SI / [2]NO");
            int respuesta = int.Parse(Console.ReadLine());

            if (respuesta == 1)
            {
                Comprar_Producto(productos_Maquina);
            }

            else if (respuesta == 2)
            {
                Console.WriteLine("Regresando al Menú...");
                Thread.Sleep(2000);
            }

            else 
            {
                Console.WriteLine("Introduce una respuesta valida");
                Otro_Producto(productos_Maquina);
            }

        }


        private void Pagar_Efectivo(Producto producto_Elegido)
        {
            double precio = producto_Elegido.Precio;
            double dineroIntroducido;

            Console.Clear();
            Console.WriteLine("Ha seleccionado el pago en efectivo");

            do
            {
                if (precio > 0)
                {
                    Console.WriteLine($"Precio[{precio}$]");
                    Console.Write("Introduce monedas o billetes: ");
                    dineroIntroducido = double.Parse(Console.ReadLine());
                    precio = precio - dineroIntroducido;
                }

                else if (precio < 0)
                {
                    Console.WriteLine("\nProceso Completado...");
                    Console.WriteLine($"Devolviendo Cambio [{precio * -1}]...");
                    Thread.Sleep(3000);
                    precio = 0;
                }

            } while(precio != 0);
        }

        private void Pagar_Tarjeta()
        {
            Console.Clear();
            Console.WriteLine("Ha seleccionado el pago en Tarjeta");

            try
            {
                int dia;
                int mes;
                int año;
                int cvc;
                BigInteger tarjeta;

                Console.WriteLine("Introduce el Número de Tarjeta: ");
                tarjeta = BigInteger.Parse(Console.ReadLine());

                do
                {

                    Console.WriteLine("Introduce el día de la fecha de expiración: ");
                    dia = int.Parse(Console.ReadLine());

                } while(dia < 1 || dia > 31);

                do
                {
                    
                    Console.WriteLine("Introduce el mes de la fecha de expiración: ");
                    mes = int.Parse(Console.ReadLine());

                } while(mes < 1 || mes > 12);

                do
                {
                    
                    Console.WriteLine("Introduce el año de la fecha de expiración: ");
                    año = int.Parse(Console.ReadLine());

                } while(año < 2024 || año > 2049);
                
                do
                {
                    
                    Console.WriteLine("Introduce el CVC ");
                    cvc = int.Parse(Console.ReadLine());

                } while(cvc < 99 || cvc > 999);

                Console.WriteLine($"Introduce el nombre asociado: ");
                string nombre = Console.ReadLine();

                Console.WriteLine($"Nombre: {nombre}");
                Console.WriteLine($"Tarjeta: {tarjeta}, Fecha: {dia}/{mes}/{año}, CVC: {cvc}");

                Console.WriteLine("\nProducto Pagado...");

                Thread.Sleep(3000);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                Thread.Sleep(1500);
                Pagar_Tarjeta();
            }
        }


        public void Comprar_Producto(List<Producto> productos_Maquina)
        {
            //Si hay productos
            if (productos_Maquina.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("<<< Productos Disponibles >>>");
                //Muestra los productos
                foreach(Producto producto in productos_Maquina)
                {
                    Console.WriteLine($"\n{producto.Mostrar_Info_Completa()}");
                }

                //Producto vacio para encontrar el ID
                Producto productoVacio = null;

                Console.Write("\nElige un producto por su ID (Presione 1 para salir):");
                int id_Elegido = int.Parse(Console.ReadLine());

                if(id_Elegido == 1)
                {
                    Program.Menu(); //Le damos al usuario la opción de salir
                }

                else
                {
                    foreach(Producto producto in productos_Maquina)
                    {
                        if (producto.ID == id_Elegido)
                        {
                            productoVacio = producto;
                        }
                    }

                    //Si se encuentra el producto
                    if (productoVacio != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"\nHa seleccionado el producto: {productoVacio.Nombre}"); 
                        Console.WriteLine($"Cuesta: {productoVacio.Precio}$");  //Mostramos el nombre y el precio del producto seleccionado
                        Console.WriteLine("\n<<< Elija un método de pago >>>");
                    
                        int metodoPago;
                        do
                        {
                            //Ponemos las opciones de pago
                            Console.WriteLine("(1) Efectivo");
                            Console.WriteLine("(2) Tarjeta");
                            Console.WriteLine("(3) SALIR");
                            metodoPago = int.Parse(Console.ReadLine());

                        }   while (metodoPago < 1 || metodoPago > 3);

                        switch(metodoPago)
                        {
                            case 1:
                            Pagar_Efectivo(productoVacio);
                            productoVacio.Cantidad = productoVacio.Cantidad - 1;
                            Otro_Producto(productos_Maquina);
                            break;
                        
                            case 2:
                            Pagar_Tarjeta();
                            productoVacio.Cantidad = productoVacio.Cantidad - 1;
                            Otro_Producto(productos_Maquina);
                            break;

                            case 3:
                            Console.WriteLine("Saliendo...");
                            break;
                        }

                        Thread.Sleep(2000);

                    }

                    else
                    {
                        Console.WriteLine("Producto no encontrado...");
                        Thread.Sleep(1500);
                        Comprar_Producto(productos_Maquina);
                    }
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("No hay productos en la maquina...");
                Console.WriteLine("Regresando al menú...");
                Thread.Sleep(2000);
            }
        }



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
