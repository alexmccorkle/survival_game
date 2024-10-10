using System;
using System.Collections.Generic;


namespace SurvivalGame
{
  class World
  {
    public int Width { get; } // Only get here because we want this readonly/immutable
    public int Height { get; }
    private Dictionary<(int, int), List<object>> map;

    public World(int width, int height)
    {
      Width = width;
      Height = height;
      map = new Dictionary<(int, int), List<object>>();
    }

    public void AddObject(int x, int y, object obj)
    {
      if (!map.ContainsKey((x, y)))
      {
        map[(x, y)] = new List<object>();
      }
      map[(x, y)].Add(obj);
    }

    public List<object> GetObjects(int x, int y)
    {
      return map.ContainsKey((x, y)) ? map[(x, y)] : new List<object>();
    }
  }
}