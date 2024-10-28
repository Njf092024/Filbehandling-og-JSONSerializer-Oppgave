namespace Filbehandling_og_JSONSerializer_Oppgave;
using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("what is your name?");
            string? name = Console.ReadLine();
            Console.WriteLine("How old are you?");
            string? ageInput = Console.ReadLine();
            int age;
            while(!int.TryParse(ageInput, out age))
            {
                Console.WriteLine("There was error with the data submitted, please input your age using numbers.");
                ageInput = Console.ReadLine();
            }
        }
        catch(Exception exception)
        {
            Console.WriteLine($"{exception.Message}\n");
        }
    }
}
