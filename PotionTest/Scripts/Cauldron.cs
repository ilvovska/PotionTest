using System;
using System.Collections.Generic;
using System.Linq;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts
{
  public class Cauldron
  {
    public Potion CookPotion(List<Ingredient> ingredients)
    {
      Dictionary<Type, Effect> potionEffects = new Dictionary<Type, Effect>();

      foreach (var ingredient in ingredients)
      {
        foreach (var effect in ingredient.Effects)
        {
          var type = effect.Type;
          if (potionEffects.ContainsKey(type))
          {
            effect.Apply(potionEffects);
          }
          else
          {
            potionEffects.Add(type, effect.Copy);
          }
        }
      }

      return new Potion(CookPotion(potionEffects.Values.ToList()));
    }

    private List<IPotionEffect> CookPotion(List<Effect> effects)
    {
      List<IPotionEffect> finalEffects = new List<IPotionEffect>();
      foreach (var effect in effects)
      {
        if (effect.FinalEffectWithAllEffects is IPotionEffect potionEffect)
          finalEffects.Add(potionEffect);
      }

      return finalEffects;
    }
  }
}