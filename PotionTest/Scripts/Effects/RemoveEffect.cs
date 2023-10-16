using System;
using System.Collections.Generic;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts.Effects
{
  public class RemoveEffect : Effect, IEffectEffect
  {
    public Effect Effect { get; set; }
    public override Type Type => Effect.Type;
    public override string Description => $"Remove all effects of type {Effect.Type.Name}";
    public override Effect Copy => new RemoveEffect(Effect.Copy);

    public RemoveEffect(Effect effect)
    {
      Effect = effect;
    }

    public override void Apply(Dictionary<Type, Effect> potionEffects)
    {
      Effect = potionEffects[Type];
      potionEffects[Type] = this;
    }
  }
}