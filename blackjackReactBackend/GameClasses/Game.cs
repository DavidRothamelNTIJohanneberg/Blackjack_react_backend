using System.Runtime.InteropServices;

namespace blackjackReactBackend.GameClasses
{
    public class Game
    {
        public int amount_of_players = 1;

        public Game()
        {
            Game.AllocConsole();//Startar console

            Console.WriteLine("Hello World");

            GameLoop.Build(amount_of_players);

            while (true) { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }
        //Gör något med consolen
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
