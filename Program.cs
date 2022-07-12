using System;
using Sword.Directing;
using Sword.Services;

namespace Sword
{
    public class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(SceneManager.VideoService);
            director.StartGame();
        }
    }
}