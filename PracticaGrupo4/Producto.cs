namespace PracticaGrupo4
{
    public class Producto
    {
        public string? Nombre {get; set;}
        public int Cantidad {get; set;}
        public double Precio {get; set;}
        public string? Descripcion {get; set;}

        

        public string Mostrar_info()
        {
            return $"Producto: {Nombre}, Cantidad: {Cantidad}\n Precio: {Precio}, Descripción:{Descripcion}";
        }
    }
}
