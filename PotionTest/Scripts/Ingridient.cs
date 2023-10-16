using System;
using System.Collections.Generic;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts
{
  public class Ingredient
  {
    private readonly List<Effect> _effects;

    public List<Effect> Effects => _effects;

    public Ingredient(List<Effect> effects)
    {
      _effects = effects;
    }
    
    public void Description()
    {
      Console.WriteLine("Ingredient: ");
      foreach (var effect in _effects) 
        Console.WriteLine($"{effect.Description}");
    }
  }
}