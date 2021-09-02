using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Jurassic Park!");

      // Test Code
      // DinosaurDatabase.Add("carnivore", "Godzilla", 328_000_000, 1);
      // DinosaurDatabase.Add("carnivore", "T-Rex", 13_000, 1);
      // DinosaurDatabase.Add("carnivore", "Steve", 8_000, 2);
      // DinosaurDatabase.Add("herbivore", "Sarah", 12_500, 3);
      // DinosaurDatabase.Add("herbivore", "Buttons", 2, 100);

      // DinosaurDatabase.Summary();
     
      // DinosaurDatabase.Remove("Godzilla");

      // DinosaurDatabase.Transfer("Buttons", 1000);

      // DinosaurDatabase.ViewDinos("Name");
      // DinosaurDatabase.ViewDinos("Enclosure");

      // DinosaurDatabase.Summary();

      bool keepGoing = true;
      string input = "";

      while (keepGoing)
      {
          Console.WriteLine("========================");
          Console.WriteLine("What do you want to do?");
          Console.WriteLine("(A)dd a dino");
          Console.WriteLine("(R)emove a dino");
          Console.WriteLine("(T)ransfer a dino");
          Console.WriteLine("(S)ummarize the dinos");
          Console.WriteLine("(V)iew the dinos in a specified order");
          Console.WriteLine("(Q)uit?");

          input = Console.Readline().ToUpper();

          switch (input)
          {
            case "A":
                string newDiet = "";
                string newName = "";
                int newWeight = "";
                int newEnclosure = ""; 

                Console.Write("Is your dino a (H)erbivore or (C)arnivore? ");
                string response = Console.Readline().ToUpper();
                if (response == "H")
                {
                    newDiet = "herbivore";
                }
                else if (response == "C")
                {
                    newDiet = "carnivore";
                } 
                else 
                {
                  Console.WriteLine("Invalid diet type!");
                  break;
                }

                Console.Write("What is your new dino's name? ");
                newName = Console.Readline();
                
                Console.Write("What is your new dino's weight in pounds? ");
                newWeight = int.Parse(Console.Readline());
                
                Console.Write($"Which enclosure would you like to place {newName} in? ");
                newEnclosure = nt.Parse(Console.Readline());

                DinosaurDatabase.Add(newDiet, newName, newWeight, newEnclosure);

              break;
            case "R":
              Console.Write("What is the name of the dino you want to remove? ");
              Dinosaur dinoBeingRemoved = DinosaurDatabase.Remove(Console.Readline());

              if (dinoBeingRemoved != null)
              {
                Console.WriteLine($"{dinoBeingRemoved.Name} has been removed!");
              }
              else
              {
                Console.WriteLine("This dino does not exist!");
              }
              break;
            case "T":
              Console.Write("What is the name of the dino you want to transfer? ");
              string transferDino = Console.Readline();

              Console.WriteLine("Which # enclosure should we move the dino to?");
              int newEnclosure = int.Parse(Console.Readline());

              Dinosaur dinoBeingTransferred = DinosaurDatabase.Transfer(transferDino, newTransferEnclosure);

              if (dinoBeingTransferred != null)
              {
                Console.WriteLine($"{dinoBeingTransferred.Name} has been transferred!");
              }
              else
              {
                Console.WriteLine("This dino does not exist!");
              }
              break;
            case "S":
              DinosaurDatabase.Summary();
              break;
            case "V":
            
              break;
            case "Q":
              keepGoing = false;
              break;
            default:
              Console.WriteLine("Invalid input!");
              break;
            
          }
          // {
          //   case value1:
          //     break;
          //   default:
          //     break;
          // }
          
      }

      Console.WriteLine("Goodbye!");
    }

  }

  static class DinosaurDatabase
  {
    static List<Dinosaur> dinos = new List<Dinosaur>() {};

    public static void ViewDinos(string orderBy)
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

       dinos.ForEach(dino => dino.Description());
       Console.WriteLine("=======================================================");
     }
     
     public static Dinosaur Add(string diet, string name, int weight, int enclosure)
     {
       Dinosaur newDino = new Dinosaur(diet, name, weight, enclosure);
       dinos.Add(newDino);
       return newDino;
     }
   // Remove
    public static Dinosaur Remove(string name)
    {
        Dinosaur dinoToRemove = dinos.FirstOrDefault(dino => dino.Name.ToLower() == name.ToLower());
        if(dinoToRemove != null)
        {
          dinos.Remove(dinoToRemove);
          Console.WriteLine("Dino removed!");
        }

        return dinoToRemove;
    }
// Transfer
    public static Dinosaur Transfer(string name, int newEnclosure)
    {
      Dinosaur transferDino = dinos.FirstOrDefault(dino => dino.Name == name);

      if(transferDino != null)
        {
          transferDino.EnclosureNumber = newEnclosure;
          Console.WriteLine("Dino updated!");
        }

        return transferDino;
    }

    public static void Summary()
    {
       int herbCount = dinos.Where(dino => dino.DietType == "herbivore").Count();
       int carnCount = dinos.Where(dino => dino.DietType == "carnivore").Count();

       Console.WriteLine($"There are {herbCount} herbivores and {carnCount} carnivores in our park!");
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
      
    }

  }
}
