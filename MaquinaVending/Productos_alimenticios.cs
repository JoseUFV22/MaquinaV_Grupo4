namespace PracticaGrupo4
{
    internal class Productos_Alimenticios : Producto
    {

        public int Calorias { get; set; }

        public int Contenido_de_grasa { get; set; }

        public int Contenido_de_azucar { get; set; }

        public Productos_Alimenticios() { }

        public override string Mostrar_Info_Completa()
        {
            return $"{base.Mostrar_Info_Completa()}\n Calorías:{Calorias}, Contenido Graso{Contenido_de_grasa}, Azúcares: {Contenido_de_azucar}";
        }
    }
}
