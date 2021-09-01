using System;
using System.Collections.Generic;

namespace JurassicPark
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Jurassic Park!");

      // Test Code
      DinosaurDatabase.Add("carnivore", "Godzilla", 328_000_000, 1);
      DinosaurDatabase.Add("carnivore", "T-Rex", 13_000, 1);
      DinosaurDatabase.Add("carnivore", "Steve", 8_000, 2);
      DinosaurDatabase.Add("herbivore", "Sarah", 12_500, 3);
      DinosaurDatabase.Add("herbivore", "Buttons", 2, 100);

      DinosaurDatabase.VeiwDinos("Name");
      Console.WriteLine("=============================");
      DinosaurDatabase.VeiwDinos("Enclosure");
    }

  }

  static class DinosaurDatabase
  {
    static List<Dinosaur> dinos = new List<Dinosaur>() {};

    public static void VeiwDinos(string orderBy)
    {
      
      if (dinos.Count == 0)
     
      {
        Console.WriteLine("Who let the dinos out???");
        return;
      }
     
     if (orderBy == "Name")

     {
        
        dinos = dinos.OrderBy(dino => dino.Name).ToList<Dinosaur>();

     }
     else
       if(orderBy == "Enclosure")
       {
          dinos = dinos.OrderBy(dino => dino.EnclosureNumber).ToList<Dinosaur>();
       }

       dinos.ForEach(dino => dino.Description
       
     }
     
     public static Dinosaur Add(string diet, string name, int weight, int enclosure)
     {
       Dinosaur newDino = new Dinosaur(diet, name, weight, enclosure);
       dinos.Add(newDino);
       return newDino;
     }
    

  }
  public class Dinosaur
  {

  // Create a class to represent your dinosaurs. The class should have the following properties

// Name
    public string Name { get; set; }
// DietType - This will be "carnivore" or "herbivore"
    public string DietType { get; set; }
// WhenAcquired - This will default to the current time when the dinosaur is created
    public DateTime WhenAcquired { get; set; }
// Weight - How heavy the dinosaur is in pounds.
    public int Weight { get; set; }
// EnclosureNumber - the number of the pen the dinosaur is in
    public int EnclosureNumber { get; set; }

    public Dinosaur(string diet, string name, int weight, int enclosure) 
    {
      DietType = diet;
      Name = name;
      WhenAcquired = DateTime.Now; 
      Weight = weight;
      EnclosureNumber = enclosure; 
    }

// Add a method Description to your class to print out a description of the dinosaur to include all the properties. 
// Create an output format of your choosing. Feel free to be creative.
    public void Description()
    {
      Console.WriteLine($"{Name} is a {DietType} that was acquired {WhenAcquired}. {Name} weighs {Weight} pounds and lives in pen number {EnclosureNumber}! ");
      Console.WriteLine("=============================");
      
    }

  }
}
