using System;
using System.Collections.Generic;
using PotionTest.Scripts;
using PotionTest.Scripts.Effects;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      var cauldron = new Cauldron();

      List<Ingredient> ingredients = new List<Ingredient>()
      {
        new Ingredient(new List<Effect>
        {
          new HealingEffect(50),
          new ModifierMultiplierEffect(new HealingEffect(0), 2)
        }),
        new Ingredient(new List<Effect>()
        {
          new HealingEffect(-20),
          new InvisibilityEffect(15),
          new AttackSpeedEffect(80, 60),
          new ModifierMultiplierEffect(new AttackSpeedEffect(0, 0), 5)
        }),
        new Ingredient(new List<Effect>()
        {
          new InvisibilityEffect(100),
          new RemoveEffect(new HealingEffect(0))
        }),
        new Ingredient(new List<Effect>()
        {
          new AttackSpeedEffect(50, 10),
          new ModifierMultiplierEffect(new HealingEffect(0), 10)
        }),
        new Ingredient(new List<Effect>()
        {
          new HealingEffect(5),
          new AttackSpeedEffect(10, 10),
          new TimeMultiplierEffect(new InvisibilityEffect(0),10)
        })
      };

      Cook(cauldron, new List<Ingredient> { ingredients[0], ingredients[1] });
      Cook(cauldron, new List<Ingredient> { ingredients[0], ingredients[1], ingredients[3] });
      Cook(cauldron, new List<Ingredient> { ingredients[2], ingredients[4] });
      Cook(cauldron, new List<Ingredient> { ingredients[0], ingredients[2], ingredients[1] });
      Cook(cauldron, new List<Ingredient> { ingredients[2], ingredients[1], ingredients[4], ingredients[0] });
    }

    private static void Cook(Cauldron cauldron, List<Ingredient> ingredients)
    {
      foreach (var ingredient in ingredients)
        ingredient.Description();
      var potion = cauldron.CookPotion(ingredients);
      potion.Drink();
      Console.WriteLine();
    }
  }
}