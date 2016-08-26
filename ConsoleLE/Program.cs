using Infrastructure;
using System;
using Domain;
using Repository.Interfaces;

namespace ConsoleLE
{
    class Program
    {
        private static IWordRepository _wordRepository;

        static Program()
        {
            ServiceLocator.RegisterAll();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("start...");
            _wordRepository = ServiceLocator.Get<IWordRepository>();
            var word = new Word("However", "asdsad", "asdsad", "oricum, in orice caz");
            _wordRepository.Save(word);
            Console.WriteLine("Press any key to quit...");

            Console.ReadKey();
        }
    }
}
