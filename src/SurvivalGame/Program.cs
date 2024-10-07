using System;

namespace SurvivalGame
{
  class Game
  {
    private Player player;
    private Random random;
    private int turns;

    public Game()
    {
      player = new Player();
      random = new Random();
      turns = 0;
    }

    public void Run()
    {
      while (player.Health > 0)
      {
        turns++;
        Console.WriteLine($"\n--- Turn {turns} ---");
        player.DisplayStatus();
        Console.WriteLine("Choose a direction to search for food, or rest!");
        Console.WriteLine("Up, Down, Left, Right or Rest if you need");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine().ToLower();
        {
          switch (choice)
          {
            case "up":
            case "down":
            case "left":
            case "right":
              // Adjust probability of finding food here
              if (random.Next(3) == 0)
              {
                Console.WriteLine("\nYou found some food!");
                player.Hunger += 20;
                if (player.Hunger > Player.MaxHunger) player.Hunger = Player.MaxHunger;
                player.foundFood = true;
              }
              else
              {
                Console.WriteLine("\nYou couldn't find any food.");
              }
              break;
            case "rest":
              Console.WriteLine("\nYou rest for a while.");
              player.Health += 10;
              if (player.Health > Player.MaxHealth) player.Health = Player.MaxHealth;
              break;
            default:
              Console.WriteLine("\nInvalid choice. Skipping turn.");
              break;
          }

          player.UpdateStatus();
        }
      }
      Console.WriteLine($"\nGame Over! You survived for {turns} turns.");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Game game = new Game();
      game.Run();
    }
  }
}
