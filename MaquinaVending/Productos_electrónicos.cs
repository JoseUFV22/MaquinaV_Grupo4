namespace PracticaGrupo4
{
    internal class Productos_electrónicos : Producto {

        public string Tipo_de_materiales { get; set; }

        public bool Pilas { get; set; }

        public bool Precargado { get; set; }


        public Productos_electrónicos() { }

        public Productos_electrónicos (string tipo_de_materiales, bool pilas, bool precargado)
        {

            Tipo_de_materiales = tipo_de_materiales;

            Pilas = pilas;

            Precargado = precargado;

        }


    }
}
