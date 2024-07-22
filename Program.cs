using System;
using System.Configuration;
using System.Text.Json;
using SerializeDeserializeOnLists.models;

namespace SerializeDeserializeOnLists
{
    internal class Program
    {
        static string path = ConfigurationManager.AppSettings["filePath"]!.ToString();

        static void Main(string[] args)
        {

            if (File.Exists(path))
            {
                //deserialize the list of persons from the file
                DeserializeObject();
            }
            else
            {
                //create a list of person objects
                List<Person> persons = new List<Person>
            {
                new Person(101, "John", "john@gmail.com"),
                new Person(102, "Jack", "jack@gmail.com"),
                new Person(103, "Bob", "bob@gmail.com"),
                new Person(104, "Jill", "jill@gmail.com"),
                new Person(105, "Mack", "mach@gmail.com")
            };

                //serialize the list of persons to the file
                SerializeObjects(persons);
            }

        }
        static void SerializeObjects(List<Person> persons)
        {
            //here we open the file for writing
            using (StreamWriter sw = new StreamWriter(path))
            {

                //serialize the list of persons and write it to the file
                sw.WriteLine(JsonSerializer.Serialize(persons));
                Console.WriteLine("==========Serialized Objects==========");
                Console.WriteLine("Persons Objects Written To File");
            }
        }
        static void DeserializeObject()
        {
            //open the file for reading
            using (StreamReader sr = new StreamReader(path))
            {

                //read the json file and deserialize it to a list of persons
                List<Person> persons = JsonSerializer.Deserialize<List<Person>>(sr.ReadToEnd());

                if (persons != null)
                {
                    Console.WriteLine("==========Deserialized Objects==========");
                    foreach (var person in persons)
                    {
                        Console.WriteLine($"Id: {person.Id}\n" +
                            $"Name: {person.Name}\n" +
                            $"Email: {person.Email}\n");
                    }
                    Console.WriteLine($"Total Persons are: {persons.Count}");
                }
                else
                {
                    Console.WriteLine("No data found!");
                }
            }

        }
    }
}
