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
            string filePath = "person.json";

            List<Person> people = new List<Person>();
            
            Console.WriteLine("what is your name?");
            string? name = Console.ReadLine();
            Console.WriteLine("What is your level?");
            string? LevelInput = Console.ReadLine();
            int level;
            while(!int.TryParse(LevelInput, out level))
            {
                Console.WriteLine("There was an error with the input");
                LevelInput = Console.ReadLine();
            }



            Console.WriteLine("How old are you?");
            string? ageInput = Console.ReadLine();
            int age;
            while(!int.TryParse(ageInput, out age))
            {
                Console.WriteLine("There was error with the data submitted, please input your age using numbers.");
                ageInput = Console.ReadLine();
            }
            Console.WriteLine("What city are you from?");
            string? city = Console.ReadLine();
            var person = new Person 
            {
                Name = name,
                Age = age,
                City = city,
                Level = level,
            };
            Console.WriteLine($"Your name is: {person.Name} and you are {person.Age} old. You reside in {person.City}, and your level is {person.Level}");

            string json = JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented =  true });

            File.WriteAllText(filePath, json);

            Console.WriteLine("Data was succesfully written to the JSON object!");
        }

        catch(IOException exception)
        {
            Console.WriteLine($"An error occured while attempting to write to the file person.json: {exception.Message}");
        }
        catch(Exception exception)
        {
            Console.WriteLine($"{exception.Message}\n");
        }
    }
}
