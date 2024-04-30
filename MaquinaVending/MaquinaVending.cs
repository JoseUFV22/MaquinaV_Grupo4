#pragma warning disable CS8604
#pragma warning disable CS8600
#pragma warning disable CS8601

namespace PracticaGrupo4
{
    public static class MaquinaVending
    {
        public static void CargarProductosEnArchivo(List<Producto> productos_Maquina)
        {
            if (productos_Maquina.Count > 0) //Si tenemos productos
            {
                File.Create("productos.csv").Close(); //Creamos o sobreescribimos el archivo
                foreach (Producto p in productos_Maquina)
                {
                    p.ToFile(); //Gurdamos cada contenido en el archivo
                }
            }
        }

        public static void CargarProductosDeArchivo(List<Producto> productos_Maquina)
        {
            if (File.Exists("productos.csv"))
            {
                using (StreamReader sr = new StreamReader("productos.csv"))
                {
                    string linea;

                    while ((linea = sr.ReadLine()) != null)
                    {

                        string[] datos = linea.Split(';');
                        if (datos[7] == "Material_Precioso") 
                        {
                            Materiales_preciosos p = new Materiales_preciosos((datos[0]), int.Parse(datos[1]), double.Parse(datos[2]), datos[3], int.Parse(datos[4]), datos[5], int.Parse(datos[6]));
                            productos_Maquina.Add(p);
                        }
                        else if (datos[8] == "Producto_Electronico")
                        {
                            Productos_electrónicos p = new Productos_electrónicos((datos[0]), int.Parse(datos[1]), double.Parse(datos[2]), datos[3], int.Parse(datos[4]), datos[5], bool.Parse(datos[6]), bool.Parse(datos[7]));
                            productos_Maquina.Add(p);
                        }
                        else if (datos[9] == "Producto_Alimenticio")
                        {
                            Productos_Alimenticios p = new Productos_Alimenticios((datos[0]), int.Parse(datos[1]), double.Parse(datos[2]), datos[3], int.Parse(datos[4]), int.Parse(datos[5]), int.Parse(datos[6]), int.Parse(datos[7]), int.Parse(datos[8]));
                            productos_Maquina.Add(p);
                        }

                    }
                }
                Console.WriteLine("productos cargados correctamente.");
            }

            else
            {
                Console.WriteLine("El archivo de productos no existe. Creando uno nuevo...");
                File.Create("productos.csv").Close();
            }
        }

        public static void MostarInfoProd(List<Producto> productos_Maquina)
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
