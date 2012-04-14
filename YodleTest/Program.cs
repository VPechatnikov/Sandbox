using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YodleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var quit = false;
            do
            {
                Console.WriteLine("Type m for missing letters, a for animation");
                var reply = Console.ReadLine();
                if (reply.StartsWith("m"))
                    RunMissingLetters();
                if (reply.StartsWith("a"))
                    RunAnimation();
                else Console.WriteLine("Invalid choice.");
                Console.WriteLine("Type q to quit, enter to go again.");
                reply = Console.ReadLine();
                quit = reply.StartsWith("q");
            }
            while (!quit);
        }

        private static void RunAnimation()
        {
            var animation = new Animation();
            Console.WriteLine("Input Speed: ");
            var speed = Double.Parse(Console.ReadLine().Trim());
            Console.WriteLine("Input initial state: ");
            var state = Console.ReadLine();
            Console.WriteLine("Animation: ");
            foreach (var positionState in animation.Animate(speed, state))
                Console.WriteLine(positionState);

        }

        private static void RunMissingLetters()
        {
            var missingLetters = new MissingLetters();
            Console.WriteLine("Input Sentence To Test: ");
            var sentence = Console.ReadLine();
            Console.WriteLine("Result: " + missingLetters.GetMissingLetters(sentence));
        }

    }
}
