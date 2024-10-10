
using System;
using System.Collections.Generic;

namespace SurvivalGame
{
  class Monster
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }

    public Monster(string name, int health, int strength)
    {
      Name = name;
      Health = health;
      Strength = strength;
    }

    public void Attack(Player player)
    {
      player.Health -= Strength;
      if (player.Health < 0) player.Health = 0;
    }
  }
}