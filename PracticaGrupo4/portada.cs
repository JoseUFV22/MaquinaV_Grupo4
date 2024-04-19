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
             `Y88888P'   8 8888                `8.`          
             ";



        static string portada1 = @"
____ ___ _______________   ____
|    |   \\_   _____/\   \ /   /
|    |   / |    __)   \   Y   / 
|    |  /  |     \     \     /  
|______/   \___  /      \___/   
               \/               ";
    

        static string portada2 = @"
░▒▓█▓▒░░▒▓█▓▒░▒▓████████▓▒░▒▓█▓▒░░▒▓█▓▒░ 
░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░ 
░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░       ░▒▓█▓▒▒▓█▓▒░  
░▒▓█▓▒░░▒▓█▓▒░▒▓██████▓▒░  ░▒▓█▓▒▒▓█▓▒░  
░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░        ░▒▓█▓▓█▓▒░   
░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░        ░▒▓█▓▓█▓▒░   
 ░▒▓██████▓▒░░▒▓█▓▒░         ░▒▓██▓▒░    
";

        static string portada3 = @"
__/\\\________/\\\__/\\\\\\\\\\\\\\\__/\\\________/\\\_        
 _\/\\\_______\/\\\_\/\\\///////////__\/\\\_______\/\\\_       
  _\/\\\_______\/\\\_\/\\\_____________\//\\\______/\\\__      
   _\/\\\_______\/\\\_\/\\\\\\\\\\\______\//\\\____/\\\___     
    _\/\\\_______\/\\\_\/\\\///////________\//\\\__/\\\____    
     _\/\\\_______\/\\\_\/\\\________________\//\\\/\\\_____   
      _\//\\\______/\\\__\/\\\_________________\//\\\\\______  
       __\///\\\\\\\\\/___\/\\\__________________\//\\\_______ 
        ____\/////////_____\///____________________\///________
";

        static string portada4 = @"
_____  _____________    __
__  / / /__  ____/_ |  / /
_  / / /__  /_   __ | / / 
/ /_/ / _  __/   __ |/ /  
\____/  /_/      _____/   
                          ";



        public static void introducir_Portada()
        {
            Random random = new Random();

            switch (random.Next(0,5))
            {
                case 0:
                Console.Clear();
                Console.WriteLine(portada0);
                break;

                case 1:
                Console.Clear();
                Console.WriteLine(portada1);
                break;

                case 2:
                Console.Clear();
                Console.WriteLine(portada2);
                break;

                case 3:
                Console.Clear();
                Console.WriteLine(portada3);
                break;

                case 4:
                Console.Clear();
                Console.WriteLine(portada4);
                break;

            }            
        }

        public static void Cambiar_Color()
        {
            Random random = new Random();

            switch (random.Next(0,5))
            {
                case 0:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;

                case 1:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;

                case 2:
                Console.ForegroundColor= ConsoleColor.Yellow;
                break;

                case 3:
                Console.ForegroundColor = (ConsoleColor)random.Next(255,0);
                break;

                case 4:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            }            


        }



    }
}
