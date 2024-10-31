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
            bool exit = false;

            List<Person>? people = new List<Person>();
            if (File.Exists(filePath))
            {
                string? exisitingJSON = File.ReadAllText(filePath);
                Console.WriteLine($"Data already exists within the file person.json {File.ReadAllText(filePath)}");
                if(!string.IsNullOrWhiteSpace(exisitingJSON))
                {
                    people = JsonSerializer.Deserialize<List<Person>>(exisitingJSON);
                }

            }
            
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
            var newPerson = new Person 
            {
                Name = name,
                Age = age,
                City = city,
                Level = level,
            };
            people.Add(newPerson);
            Console.WriteLine($"Your name is: {newPerson.Name} and you are {newPerson.Age} old. You reside in {newPerson.City}, and your level is {newPerson.Level}");

            string json = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented =  true });

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
