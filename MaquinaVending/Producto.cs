namespace PracticaGrupo4
{
    public class Producto
    {
        public string? Nombre {get; set;}
        public int Cantidad {get; set;}
        public double Precio {get; set;}
        public string? Descripcion {get; set;}
        public int ID {get; set;}
        
        public string Mostrar_Info()
        {
            return $"ID:[{ID}] Producto: [{Nombre}] Cantidad: [{Cantidad}]";
        }

        public string Mostrar_Info_Completa()
        {
            return $"ID:[{ID}] Producto: [{Nombre}] Cantidad: [{Cantidad}]\n Precio: [{Precio}] Descripción:[{Descripcion}]";
        }
    }
}
