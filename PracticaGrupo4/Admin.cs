#pragma warning disable CS8604

namespace PracticaGrupo4
{
    class Admin : Usuario
    {
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
                    Console.Clear();
                    Console.WriteLine("<<< Añadiendo existencias a un producto >>>");
                    Console.WriteLine("Selecciona un producto: ");

                    //No terminado

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
