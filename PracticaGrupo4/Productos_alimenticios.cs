namespace PracticaGrupo4
{
    internal class Productos_Alimenticios : Producto
    {

        public int Calorías { get; set; }

        public int Contenido_de_grasa { get; set; }

        public int Contenido_de_azúcar { get; set; }

        public Productos_Alimenticios() { }

        public Productos_Alimenticios(int calorías, int contenido_de_grasa, int contenido_de_azúcar)
        {

            Calorías = calorías;

            Contenido_de_grasa = contenido_de_grasa;

            Contenido_de_azúcar = contenido_de_azúcar;

        }



    }
}
