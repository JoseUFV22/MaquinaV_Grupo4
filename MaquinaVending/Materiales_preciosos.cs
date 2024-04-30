#pragma warning disable CS8603
#pragma warning disable CS8604
#pragma warning disable CS8618

namespace PracticaGrupo4
{
    internal class Materiales_preciosos : Producto 
    {
        
        public string Tipo_de_material {  get; set; }

        public int Peso_en_gramos {  get; set; }

        public Materiales_preciosos() { }
        public Materiales_preciosos(string nombre, int cantidad, double precio, string descripcion, int id, string tipomaterial, int pesogramos )
            :base(nombre, cantidad, precio, descripcion, id) 
        {
            Tipo_de_material = tipomaterial;
            Peso_en_gramos = pesogramos;
        }

        public override string Mostrar_Info_Completa()
        {
            return $"{base.Mostrar_Info_Completa()}\nMateriales: {Tipo_de_material},Peso: {Peso_en_gramos}g.";
        }

        public override void ToFile()
        {
            StreamWriter sw = new StreamWriter("productos.csv", true);
            sw.WriteLine($"{Nombre};{Cantidad};{Precio};{Descripcion};{ID};{Tipo_de_material};{Peso_en_gramos};Material_Precioso");
            sw.Close();
        }
    }
}
