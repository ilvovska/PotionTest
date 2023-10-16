using System;
using System.Collections.Generic;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts.Effects
{
  public class TimeMultiplierEffect : Effect, IModifierEffect, IEffectEffect
  {
    public double Modifier { get; set; }
    public Effect Effect { get; set; }
    public override Type Type => Effect.Type;
    public override string Description => $"Multiply {Effect.Type.Name} time by {Modifier}";
    public override Effect Copy => new TimeMultiplierEffect(Effect.Copy, Modifier);
    public override Effect FinalEffect => Effect;

    public override Effect FinalEffectWithAllEffects
    {
      get
      {
        if (FinalEffect is ITimedEffect effect)
          effect.Time *= Modifier;

        return Effect;
      }
    }

    public TimeMultiplierEffect(Effect effect, double modifier)
    {
      Effect = effect;
      Modifier = modifier;
    }

    public override void Apply(Dictionary<Type, Effect> potionEffects)
    {
      TimeMultiplierEffect effect = EffectsTools.GetEffectByType<TimeMultiplierEffect>(potionEffects[Type]);
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