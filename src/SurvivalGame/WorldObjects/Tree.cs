
using System;
using System.Collections.Generic;

namespace SurvivalGame
{
  class Tree
  {
    public int Wood { get; set; }
    public Tree()
    {
      Wood = 100;
      // Could implement some form of scaling here based on e.g. Character Level or World Tier(?)
      // The higher the level the more Wood available per tree? Or different kinds of trees.
    }

    public int Harvest(int strength)
    {
      int harvested = Math.Min(strength, Wood);
      // Will either get wood = strength level, or if less wood than remaining strength, will get the remainder
      // Probably better to base this on an item level (i.e. axe lvl 3)
      Wood -= harvested;
      return harvested;
    }
  }
}