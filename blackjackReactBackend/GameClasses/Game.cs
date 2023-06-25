using System.Runtime.InteropServices;

namespace blackjackReactBackend.GameClasses
{
    public class Game
    {
        Player player;

        public Game()
        {
            Game.AllocConsole();//Startar console

            Console.WriteLine("Hello World");

            Deck.DeckBuilder(6);
            Deck.Shuffle();
            player = new(100);

            for (int i = 0; i < 2; i++)
            {
                player.hands[0].Take_card();
            }

            player.Print_hand();

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
