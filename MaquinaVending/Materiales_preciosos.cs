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

        public override string Mostrar_Info_Completa()
        {
            return $"{base.Mostrar_Info_Completa()}\n Materiales: {Tipo_de_material},Peso: {Peso_en_gramos}g.";
        }
    }
}
