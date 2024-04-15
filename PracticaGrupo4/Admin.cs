namespace PracticaGrupo4
{
    class Admin : Usuario
    {
        public override void Test()
        {
            Console.WriteLine("SI VES ESTO ES QUE EL USUARIO ES ADMIN");
            Thread.Sleep(5000);
        }
    }
}
