#pragma warning disable CS8603
#pragma warning disable CS8604
#pragma warning disable CS8618

namespace PracticaGrupo4
{
    internal class Materiales_preciosos : Producto {
        
        public string Tipo_de_material {  get; set; }

        public int Peso_en_gramos {  get; set; }

        public Materiales_preciosos() { }

        public Materiales_preciosos(string tipo_de_material, int peso_en_gramos) 
        {

            Tipo_de_material = tipo_de_material;

            Peso_en_gramos = peso_en_gramos;

        }



    }
}
