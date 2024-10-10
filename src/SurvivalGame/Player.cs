using System;
using System.Collections.Generic;

namespace SurvivalGame
{
  class Player
  {
    public int Health { get; set; }
    public int Hunger { get; set; }
    public int Strength { get; set; }
    public static int MaxHealth = 100;
    public static int MaxHunger = 100;
    public bool foundFood { get; set; }



    public Player()
    {
      Health = MaxHealth;
      Hunger = MaxHunger;
      Strength = 10;
      foundFood = false;
    }

    public void UpdateStatus()
    {
      if (Hunger > 0)
      {
        if (!foundFood)
        {
          Hunger -= 5;
        }

        if (Hunger < 0)
        {
          Hunger = 0;
        }
      }
      if (Hunger == 0)
      {
        Strength -= 1;
        Health -= 20;
      }

      if (Health < 0)
      {
        Health = 0;
      }

      foundFood = false;
    }

    public void DisplayStatus()
    {
      Console.WriteLine($"Health: {Health}/{MaxHealth}");
      Console.WriteLine($"Hunger: {Hunger}/{MaxHunger}");
    }
  }
}