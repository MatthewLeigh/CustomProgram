global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Numerics;
global using System.Security.Cryptography.X509Certificates;
global using System.Text;
global using System.Threading.Tasks;
global using SplashKitSDK;

namespace CustomProgram
{
    public class Program
    {
        public static void Main()
        {
            GameManager gameManager = new GameManager();
            Window window = gameManager.GameWindow;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                gameManager.RunCycle();

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
