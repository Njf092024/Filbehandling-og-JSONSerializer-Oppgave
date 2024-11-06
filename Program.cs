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

            while (!exit)
            { // Eirik ga meg insipirasjon for menyen, men sliter med å få menyen til å displaye skikkelig
                Console.Clear();
                Console.WriteLine("Main menu");
                Console.WriteLine("1. Add a new character");
                Console.WriteLine("2. List all characters");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                    AddNewCharacter(filePath);
                    break;
                    case "2":
                    ListAllCharacters(filePath);
                    break;
                    case "3":
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;
                    default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
                }
            }

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

    static void AddNewCharacter(string filePath)
    {
        Console.Clear();
        List<Person> people = new List<Person>();

        if (File.Exists(filePath))
        {
            string? existingJSON = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(existingJSON))
            {
                people = JsonSerializer.Deserialize<List<Person>>(existingJSON) ?? new List<Person>();
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
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();

    }

    static void ListAllCharacters(string filePath)
    {
    Console.Clear();
    Console.WriteLine("ListAllCharacters method called"); 

    if (File.Exists(filePath))
    {
        string? existingJSON = File.ReadAllText(filePath);
        Console.WriteLine($"File content: {existingJSON}"); 

        if (!string.IsNullOrWhiteSpace(existingJSON))
        {
            List<Person> people = JsonSerializer.Deserialize<List<Person>>(existingJSON) ?? new List<Person>();

            if (people.Count == 0)
            {
                Console.WriteLine("No characters found in the file.");
            }
            else
            {
                Console.WriteLine("List of characters:");
                foreach (var person in people)
                {
                    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}, Level: {person.Level}");
                }
            }
        }
        else
        {
            Console.WriteLine("No characters found.");
        }
    }
    else
    {
        Console.WriteLine("File not found.");
        
    }
        Console.ReadKey();
}
}
