using Interfaces;
using Plagins.Factories;
using Plugins.Factories;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to my programm");
        Console.WriteLine("Enter the Operation");
        Console.WriteLine("1 - Plus");
        Console.WriteLine("2 - Lenght");
        Console.WriteLine("3 - Find element");

        string membershipType = Console.ReadLine();

        CatFactory catFactory = GetCat(membershipType);
        IPlugin plugin = catFactory.GetCat();
        Console.WriteLine(plugin.Execute(new int[] {1, 2, 3}, 2));
    }

    private static CatFactory GetCat(string membershipType) => membershipType.ToLower() switch
    {
        "1" => new PlusClassFectory("Kity", "black"),
        "2" => new MeowClassFectory("Lola", "whight"),
        "3" => new CatCatFactory("Meow", "orange"),
        _ => null
    };
}