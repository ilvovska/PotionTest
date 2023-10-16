using System;
using System.Collections.Generic;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts
{
  public class Potion
  {
    private readonly List<IPotionEffect> _effects;

    public Potion(List<IPotionEffect> effects)
    {
      _effects = effects;
    }

    public void Drink()
    {
      Console.WriteLine("Potion: ");
      foreach (var effect in _effects) 
        Console.WriteLine($"{effect.Use}");
    }
  }
}