namespace PracticaGrupo4
{
    internal class Productos_Alimenticios : Producto
    {

        public int Calorias { get; set; }

        public int Contenido_de_grasa { get; set; }

        public int Contenido_de_azucar { get; set; }
        public int Peso_neto { get; set; }

        public Productos_Alimenticios() { }

        public Productos_Alimenticios(string nombre, int cantidad, double precio, string descripcion, int id, int calorias, int contenidograso, int azucares, int pesoneto)
        : base(nombre, cantidad, precio, descripcion, id)
        {
            Calorias = calorias;
            Contenido_de_grasa = contenidograso;
            Contenido_de_azucar = azucares;
            Peso_neto = pesoneto;
        }

        public override string Mostrar_Info_Completa()
        {
            return $"{base.Mostrar_Info_Completa()}\nCalorías:{Calorias}, Contenido Graso{Contenido_de_grasa}, Azúcares: {Contenido_de_azucar}, Peso neto: {Peso_neto}";
        }
        public override void ToFile()
        {
            StreamWriter sw = new StreamWriter("productos.csv", true);
            sw.WriteLine($"{Nombre};{Cantidad};{Precio};{Descripcion};{ID};{Calorias};{Contenido_de_grasa};{Contenido_de_azucar};{Peso_neto};Producto_Alimenticio");
            sw.Close();
        }
    }
}
