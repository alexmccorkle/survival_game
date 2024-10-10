using System;
using System.Collections.Generic;


namespace SurvivalGame
{
  class Game
  {
    private Player player;
    private World world;
    private Random random;
    private int turns;

    public Game()
    {
      player = new Player();
      world = new World(10, 10);
      random = new Random();
      turns = 0;
      InitializeWorld();
    }

    private void InitializeWorld()
    {
      // Add trees:
      for (int i = 0; i < 10; i++)
      {
        world.AddObject(random.Next(world.Width), random.Next(world.Height), new Tree()); // Place 3 trees in the map
      }

      // Add items:
      for (int i = 0; i < 5; i++)
      {
        world.AddObject(random.Next(world.Width), random.Next(world.Height), new GroundItem("Axe", "A tool for chopping wood!"));
        world.AddObject(random.Next(world.Width), random.Next(world.Height), new GroundItem("Mushroom", "Restores 20 health"));
      }

      // Add monsters:
      for (int i = 0; i < 3; i++)
      {
        world.AddObject(random.Next(world.Width), random.Next(world.Height), new Monster("Skeleton", 25, 5));
      }
    }

    public void Run()
    {
      int playerX = 0, playerY = 0;

      while (player.Health > 0)
      {
        turns++;
        Console.WriteLine($"\n--- Turn {turns} ---");
        player.DisplayStatus();
        Console.WriteLine($"Position: ({playerX}, {playerY})"); // ($"") is like (f"") in Python
        Console.WriteLine("Choose a direction to search for food, or rest!");
        Console.WriteLine("Up, Down, Left, Right, Rest, Inventory or Interact");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine()?.ToLower() ?? "";
        {
          switch (choice)
          {
            case "up":
              if (playerY < world.Height - 1) playerY++;
              break;
            case "down":
              if (playerY > 0) playerY--;
              break;
            case "left":
              if (playerX > 0) playerX--;
              break;
            case "right":
              if (playerX < world.Width - 1) playerX++;
              break;
            case "rest":
              Console.WriteLine("You rest for a while");
              player.Health += 10;
              if (player.Health > Player.MaxHealth) player.Health = Player.MaxHealth;
              break;
            case "inventory":
              // TODO: Implement inventory system
              Console.WriteLine("Feature not yet implemented! Working on it :)");
              break;
            case "interact":
              Interact(playerX, playerY);
              break;
            default:
              Console.WriteLine("Invalid choice. Skipping turn");
              break;

          }

          // Check for random food (Probably remove once you can pick up objects)
          if (random.Next(5) == 0)
          {
            Console.WriteLine("You found some food");
            player.Hunger += 20;
            if (player.Hunger > Player.MaxHunger) player.Hunger = Player.MaxHunger;
          }

          player.UpdateStatus();
        }
      }
      Console.WriteLine($"\nGame Over! You survived for {turns} turns.");
    }

    private void Interact(int x, int y)
    {
      List<object> objects = world.GetObjects(x, y);
      if (objects.Count == 0)
      {
        Console.WriteLine("Nothing to interact with");
        return;
      }

      foreach (var obj in objects)
      {
        if (obj is Tree tree)
        {
          int woodHarvested = tree.Harvest(player.Strength);
          Console.WriteLine($"You chopped {woodHarvested} wood from the tree");
        }
        else if (obj is GroundItem item)
        {
          Console.WriteLine($"You found {item.Name}: {item.Description}");
          // TODO: Add a choice of keep, discard (After inventory added)
        }
        else if (obj is Monster monster)
        {
          Console.WriteLine($"You encounter a {monster.Name}!");
          //TODO: Implement combat system
        }
      }
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
