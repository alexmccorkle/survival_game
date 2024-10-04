using System;

class Player
{
  public int Health { get; set; }
  public int Hunger { get; set; }
  public const int MaxHealth = 100;
  public const int MaxHunger = 100;

  public Player()
  {
    Health = MaxHealth;
    Hunger = MaxHunger;
  }

  public void UpdateStatus()
  {
    if (Hunger > 0)
    {
      Hunger -= 5;

      if (Hunger < 0)
      {
        Hunger = 0;
      }
    }
    if (Hunger == 0)
    {
      Health -= 20;
    }

    if (Health < 0)
    {
      Health = 0;
    }

  }

  public void DisplayStatus()
  {
    Console.WriteLine($"Health: {Health}/{MaxHealth}");
    Console.WriteLine($"Hunger: {Hunger}/{MaxHunger}");
  }
}

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
      Console.WriteLine("1. Search for food");
      Console.WriteLine("2. Rest");
      Console.Write("Enter your choice: ");
      if (int.TryParse(Console.ReadLine(), out int choice))
      {
        switch (choice)
        {
          case 1:
            if (random.Next(2) == 0)
            {
              Console.WriteLine("\nYou found some food!");
              player.Hunger += 20;
              if (player.Hunger > Player.MaxHunger) player.Hunger = Player.MaxHunger;
            }
            else
            {
              Console.WriteLine("\nYou couldn't find any food.");
            }
            break;
          case 2:
            Console.WriteLine("\nYou rest for a while.");
            player.Health += 10;
            if (player.Health > Player.MaxHealth) player.Health = Player.MaxHealth;
            break;
          default:
            Console.WriteLine("\nInvalid choice. Skipping turn.");
            break;
        }
      }
      else
      {
        Console.WriteLine("Invalid input. Skipping turn.");
      }
      player.UpdateStatus();
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