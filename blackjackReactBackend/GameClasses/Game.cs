using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace blackjackReactBackend.GameClasses
{
    public class Game
    {
        Game()
        {
            Game.AllocConsole();//Startar console
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
