namespace PracticaGrupo4
{
    public class Producto
    {
        public string? Nombre {get; set;}
        public int Cantidad {get; set;}
        public double Precio {get; set;}
        public string? Descripcion {get; set;}
        public int ID {get; set;}

        public Producto() { }

        public Producto(string nombre, int cantidad, double precio, string descripcion, int id)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
            Descripcion = descripcion;
            ID = id;

        }
        
        public string Mostrar_Info()
        {
            return $"ID:[{ID}] Producto: [{Nombre}] Cantidad: [{Cantidad}]";
        }

        public virtual string Mostrar_Info_Completa()
        {
            return $"ID:[{ID}] Producto:{Nombre} Cantidad:[{Cantidad}] Precio:[{Precio}$] Descripción:{Descripcion}";
        }

        public void ToFile()
        {
            StreamWriter sw = new StreamWriter("productos.txt", true);
            sw.WriteLine($"{Nombre};{Cantidad};{Precio};{Descripcion};{ID}");
            sw.Close();
        }
    }
}
