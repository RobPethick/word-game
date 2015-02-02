using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
  using System;

  class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Play();
            Console.ReadKey();
        }
    }
}
