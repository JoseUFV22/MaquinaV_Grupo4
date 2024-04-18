namespace PracticaGrupo4
{
    public static class Portada
    {
        static string portada0 = 
            @"
          8 8888      88 8 8888888888 `8.`888b           ,8' 
          8 8888      88 8 8888        `8.`888b         ,8'  
          8 8888      88 8 8888         `8.`888b       ,8'   
          8 8888      88 8 8888          `8.`888b     ,8'    
          8 8888      88 8 888888888888   `8.`888b   ,8'     
          8 8888      88 8 8888            `8.`888b ,8'      
          8 8888      88 8 8888             `8.`888b8'       
          ` 8888     ,8P 8 8888              `8.`888'        
            8888   ,d8P  8 8888               `8.`8'         
             `Y88888P'   8 8888                `8.`          ";



        static string portada1 = @"
____ ___ _______________   ____
|    |   \\_   _____/\   \ /   /
|    |   / |    __)   \   Y   / 
|    |  /  |     \     \     /  
|______/   \___  /      \___/   
               \/               ";

        public static void introducir_Portada()
        {
            Random random = new Random();

            switch (random.Next(0,4))
            {
                case 0:
                Console.WriteLine(portada0);
                break;

                case 1:
                Console.WriteLine(portada1);
                break;

                case 2:
                Console.WriteLine(portada1);
                break;

                case 3:
                Console.WriteLine(portada1);
                break;

                case 4:
                Console.WriteLine(portada1);
                break;

                case 5:
                Console.WriteLine(portada1);
                break;
            }            
        }



    }
}
