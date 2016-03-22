using System;
using WMPLib;
using System.Media;
using System.Threading;
using System.Text;

//Problem 11. Adding polynomials
//Write a method that adds two polynomials.
//Represent them as arrays of their coefficients.
//Example:
//x2 + 5 = 1x2 + 0x + 5 => {5, 0, 1}

class Test
{
    static Random rnd = new Random();
    static void Main()
    {
        //SoundPlayer player = new SoundPlayer();

        //player.SoundLocation = @"..\..\tetris.wav";
        //player.Load();
        //player.PlaySync();

        //Thread playMusic = new Thread(player.PlayLooping);
        //playMusic.Start();

        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        WindowsMediaPlayer wmp2 = new WindowsMediaPlayer();


        wmp.URL = @"C:\Users\Pariador\Desktop\Snake Basilisk\GameTeamBasilisk\Snake\Sounds\inGame.wav";
        //wmp.URL = @"C:\Users\Pariador\Desktop\Snake Basilisk\GameTeamBasilisk\Snake\Sounds\powerUp.wav";


        wmp.settings.volume = 50;


        wmp.controls.play();
        Thread.Sleep(10000);

        wmp2.URL = @"C:\Users\Pariador\Desktop\Snake Basilisk\GameTeamBasilisk\Snake\Sounds\dead.wav";
        while (true)
        {
            Thread.Sleep(5000);
            wmp2.controls.play();
        }


        wmp.controls.play();
        //Thread playMusic = new Thread(wmp.controls.play);
        //playMusic.Start();
        //Thread.Sleep(999999);

        int i = 0;
        while (true)
        {
            Console.WriteLine("WORKING");
            //i++;
        }
        //playMusic.Abort();
        //Console.WriteLine("Done");
    }

    static void printScreen(string[,] screen)
    {
        for (int row = 0; row < screen.GetLength(0); row++)
        {
            for (int col = 0; col < screen.GetLength(1); col++)
            {
                Console.Write(screen[row, col]);
            }
            Console.WriteLine();
        }
    }
}