using System;
using System.Collections.Generic;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts.Effects
{
  public class ModifierMultiplierEffect : Effect, IModifierEffect, IEffectEffect
  {
    public Effect Effect { get; set; }
    public double Modifier { get; set; }
    public override Type Type => Effect.Type;
    public override string Description => $"Multiply {Effect.Type.Name} modifier by {Modifier}";
    public override Effect Copy => new ModifierMultiplierEffect(Effect.Copy, Modifier);
    public override Effect FinalEffect => Effect;
    
    public override Effect FinalEffectWithAllEffects
    {
      get
      {
        if (FinalEffect is IModifierEffect effect)
          effect.Modifier *= Modifier;

        return Effect;
      }
    }

    public ModifierMultiplierEffect(Effect effect, double modifier)
    {
      Effect = effect;
      Modifier = modifier;
    }

    public override void Apply(Dictionary<Type, Effect> potionEffects)
    {
      ModifierMultiplierEffect effect = EffectsTools.GetEffectByType<ModifierMultiplierEffect>(potionEffects[Type]);
      if (effect != null)
      {
        effect.Modifier = Math.Max(effect.Modifier, Modifier);
        return;
      }

      Effect = potionEffects[Type];
      potionEffects[Type] = this;
    }

  }
}