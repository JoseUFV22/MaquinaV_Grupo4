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

            if (Pilas == true)
            {
                precargadoSi = "SI";
            }
            else
            {
                precargadoSi = "No";
            }

            return $"{base.Mostrar_Info_Completa()}\nMateriales: {Tipo_de_materiales}, Pilas: {pilasSi}, Precargado: {precargadoSi}";
        }
    }
}
