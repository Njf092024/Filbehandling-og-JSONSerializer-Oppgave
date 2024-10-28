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
            
        }
        catch(Exception exception)
        {
            Console.WriteLine($"{exception.Message}\n");
        }
    }
}
