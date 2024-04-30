#pragma warning disable CS8603
#pragma warning disable CS8604
#pragma warning disable CS8618


namespace PracticaGrupo4
{
    internal class Productos_electrónicos : Producto
    {

        public string Tipo_de_materiales { get; set; }

        public bool Pilas { get; set; }

        public bool Precargado { get; set; }


        public Productos_electrónicos() {}
        public Productos_electrónicos(string nombre, int cantidad, double precio, string descripcion, int id,string tipomaterial, bool pilas, bool precargado)
        : base(nombre, cantidad, precio, descripcion, id)
        {
            Pilas = pilas;
            Precargado = precargado;
            Tipo_de_materiales = tipomaterial;
        }

        public override string Mostrar_Info_Completa()
        {
            string pilasSi;
            string precargadoSi;

            if (Pilas == true)
            {
                pilasSi = "SI";
            }
            else
            {
                pilasSi = "No";
            }

            if (Precargado == true)
            {
                precargadoSi = "SI";
            }
            else
            {
                precargadoSi = "No";
            }

            return $"{base.Mostrar_Info_Completa()}\nMateriales: {Tipo_de_materiales}, Pilas: {pilasSi}, Precargado: {precargadoSi}";
        }
        public override void ToFile()
        {
            StreamWriter sw = new StreamWriter("productos.csv", true);
            sw.WriteLine($"{Nombre};{Cantidad};{Precio};{Descripcion};{ID};{Tipo_de_materiales};{Pilas};{Precargado};Producto_Electronico");
            sw.Close();
        }
    }
}
