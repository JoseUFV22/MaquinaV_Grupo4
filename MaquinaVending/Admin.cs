#pragma warning disable CS8604
#pragma warning disable CS8600
#pragma warning disable CS8601
using System.Collections;

namespace PracticaGrupo4
{
    class Admin : Usuario
    {
        //Constructores
        public Admin(){}


        //Metodos
        public override void Anadir_Producto(List<Producto> productos_Maquina)
        {
            int respuesta = 0;

            try
            {
                do
                {
                    Console.Clear();
                    Console.Write("<<< Añadir un nuevo producto[1] / Reponer un producto[2] >>>\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n</{Program.nombreUsuario}/>>> ");
                    Console.ForegroundColor= ConsoleColor.White;
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
                        int tipo = 0;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("<<< Añadiendo Nuevo Producto >>>");
                            Console.Write("Que tipo de producto es? [1/Alimenticio 2/Electrónico 3/Precioso]:"); //damos a elegir que tipo de producto vamos a añadir
                            tipo = int.Parse(Console.ReadLine());

                        }while (tipo < 1 || tipo > 3);

                        if (tipo == 1){productoNuevo = new Productos_Alimenticios();}
                        else if (tipo == 2){productoNuevo = new Productos_electrónicos();}
                        else if (tipo == 3){productoNuevo = new Materiales_preciosos();}
                        
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

                        if (productoNuevo is Productos_Alimenticios)
                        {
                            Console.Write("Introduce las calorías del producto: ");
                            ((Productos_Alimenticios)productoNuevo).Calorias = int.Parse(Console.ReadLine());
                            Console.Write("Introduce el contenido graso del producto: ");
                            ((Productos_Alimenticios)productoNuevo).Contenido_de_grasa = int.Parse(Console.ReadLine());
                            Console.Write("Introduce los azúcares del producto: ");
                            ((Productos_Alimenticios)productoNuevo).Contenido_de_azucar = int.Parse(Console.ReadLine());
                        }

                        else if (productoNuevo is Productos_electrónicos)
                        {
                            int respuestaPila = 0;
                            int respuestaCarga = 0;
                            Console.Write("Introduce el material del producto: ");
                            ((Productos_electrónicos)productoNuevo).Tipo_de_materiales = Console.ReadLine();

                            do
                            {
                                Console.Write("El producto contiene pilas? [1]SI / [2]NO ");
                                respuestaPila = int.Parse(Console.ReadLine());
                                if (respuestaPila == 1) {((Productos_electrónicos)productoNuevo).Pilas = true;}
                                else if (respuestaPila == 2) {((Productos_electrónicos)productoNuevo).Pilas = false;}
                            } while(respuestaPila < 1 || respuestaPila > 2);

                            do
                            {
                                Console.Write("El producto esta precargado? [1]SI / [2]NO ");
                                respuestaCarga = int.Parse(Console.ReadLine());
                                if (respuestaCarga == 1) {((Productos_electrónicos)productoNuevo).Precargado = true;}
                                else if (respuestaCarga == 2) {((Productos_electrónicos)productoNuevo).Precargado = false;}
                            } while(respuestaCarga < 1 || respuestaCarga > 2);
                        }

                        else if (productoNuevo is Materiales_preciosos)
                        {
                            Console.Write("Introduce el materíal del producto: ");
                            ((Materiales_preciosos)productoNuevo).Tipo_de_material = Console.ReadLine();
                            Console.Write("Introduce el peso en gramos del producto: ");
                            ((Materiales_preciosos)productoNuevo).Peso_en_gramos = int.Parse(Console.ReadLine());
                        }

                        productos_Maquina.Add(productoNuevo);
                        Console.WriteLine($"[Producto: {productoNuevo.Nombre}, añadido]");
                        Console.WriteLine("Regresando al Menú...");
                        Console.WriteLine("No presiones ninguna tecla...");
                        Thread.Sleep(1500);
                    }
                    break;


                    case 2:
                    Console.Clear();
                    Console.WriteLine("<<< Añadiendo existencias a un producto >>>\n");

                    //Si no hay productos
                    if (productos_Maquina.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("No hay productos...");
                        Console.WriteLine("Regresando al Menú...");
                        Thread.Sleep(1700);
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

                        Console.Write("\nElige un producto por su ID:");
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

                            Console.WriteLine($"\n{productoVacio.Nombre} ahora tiene: {productoVacio.Cantidad} unidades");
                            Console.WriteLine("Regresando al Menú...");
                            Thread.Sleep(2500);
                        }

                        else
                        {
                            Console.WriteLine("Producto no encontrado...");
                            Thread.Sleep(1500);
                            Anadir_Producto(productos_Maquina);
                        }
                    }
                    break;
                }
            }
            
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error:" + ex.Message);
                Anadir_Producto(productos_Maquina);
            }
        }

        public override void Anadir_Varios_Productos(List<Producto> productos_Maquina)
        {
            int respuesta = 0;

            try
            {
                do
                {
                    Console.WriteLine("Añadir varios productos[1] / Reponer varios productos[2]");
                    Console.Write($"\n</{Program.nombreUsuario}/>>> ");
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
                        int r;
                        do 
                        {
                            Producto productoNuevo = new Producto();
                            Console.Clear();
                            Console.WriteLine("<<< Añadiendo un producto >>>");
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
                            Console.WriteLine($"[Producto: {productoNuevo.Nombre}, añadido]");
                            Console.WriteLine("¿Desea seguir añadiendo productos?");
                            Console.WriteLine("Sí [1] / No [2]");
                            r = int.Parse(Console.ReadLine());

                        }while(r > 0 && r < 2);

                        Thread.Sleep(1500);
                    }

                    break;
                    case 2:
                        Console.Clear();
                    Console.WriteLine("<<< Añadiendo existencias a un producto >>>\n");

                    //Si no hay productos
                    if (productos_Maquina.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("No hay productos...");
                        Console.WriteLine("Regresando al Menú...");
                        Thread.Sleep(1700);
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

                        Console.Write("\nElige un producto por su ID:");
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

                            Console.WriteLine($"\n{productoVacio.Nombre} ahora tiene: {productoVacio.Cantidad} unidades");
                            Console.WriteLine("Regresando al Menú...");
                            Thread.Sleep(2500);
                        }

                        else
                        {
                            Console.WriteLine("Producto no encontrado...");
                            Thread.Sleep(1500);
                            Anadir_Producto(productos_Maquina);
                        }
                    }
                    break;
                }
            }
            
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error:" + ex.Message);
                Anadir_Varios_Productos(productos_Maquina);
            }
        }
    }
}

