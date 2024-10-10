namespace SurvivalGame
{
  class GroundItem
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public GroundItem(string name, string description)
    {
      Name = name;
      Description = description;
    }
  }
}

// TODO: 
// Add a list of items that is randomly picked from (i.e. different consumables, different wearables, unwanted items etc.)