#pragma warning disable CS8604
#pragma warning disable CS8600

using System.Collections;

namespace PracticaGrupo4
{
    class Admin : Usuario
    {
        //Constructores
        public Admin(){}


        //Metodos
        public override void Añadir_Producto(List<Producto> productos_Maquina)
        {
            int respuesta = 0;

            try
            {
                do
                {
                    Console.WriteLine("Añadir un nuevo producto[1] / Reponer un producto[2]");
                    respuesta = int.Parse(Console.ReadLine());
                }
                while(respuesta < 1 || respuesta > 2);
                
                switch (respuesta)
                {
                    case 1:
                    if (productos_Maquina.Count == 12)
                    {
                        Console.WriteLine("No hay espacio en la Maquina Expendedora");
                    }

                    else
                    {   
                        Producto productoNuevo = new Producto();

                        Console.Clear();
                        Console.WriteLine("<<< Añadiendo Nuevo Producto >>>");
                        Console.Write("Introduce el ID del producto: ");
                        productoNuevo.ID = int.Parse(Console.ReadLine());
                        Console.Write("Introduce el nombre del producto: ");
                        productoNuevo.Nombre = Console.ReadLine();
                        Console.Write("Introduce la cantidad del producto: ");
                        productoNuevo.Cantidad = int.Parse(Console.ReadLine());
                        Console.Write("Introduce el precio del producto: ");
                        productoNuevo.Precio = double.Parse(Console.ReadLine());
                        Console.Write("Introduce la descripción del producto: ");
                        productoNuevo.Descripcion = Console.ReadLine();

                        productos_Maquina.Add(productoNuevo);
                        Console.WriteLine($"Producto: {productoNuevo.Nombre}, añadido");
                    }
                    break;

                    case 2:
                    Console.WriteLine("<<< Añadiendo existencias a un producto >>>");

                    //Si no hay productos
                    if (productos_Maquina.Count == 0)
                    {
                        Console.WriteLine("No hay productos...");
                    }

                    else
                    {
                        //Muestra todos los productos
                        foreach (Producto producto in productos_Maquina)
                        {
                            Console.WriteLine(producto.Mostrar_Info());
                        }

                        //Producto vacio para encontrar el ID
                        Producto productoVacio = null;

                        Console.WriteLine("Elige un producto por su ID:");
                        int id_Elegido = int.Parse(Console.ReadLine());

                        foreach(Producto producto in productos_Maquina)
                        {
                            if (producto.ID == id_Elegido)
                            {
                                productoVacio = producto;
                            }
                        }

                        if (productoVacio != null)
                        {
                            Console.WriteLine("Cuantas unidades quieres añadir: ");
                            int cantidadNueva = int.Parse(Console.ReadLine());
                            productoVacio.Cantidad += cantidadNueva;

                            Console.WriteLine($"{productoVacio.Nombre} ahora tiene: {productoVacio.Cantidad} unidades");
                            Thread.Sleep(3000);
                        }

                        else
                        {
                            Console.WriteLine("Producto no encontrado...");
                        }
                    }
                    break;
                }
            }

            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error:" + ex.Message);
                Añadir_Producto(productos_Maquina);
            }
        }
    }
}
