using System;
using System.Collections.Generic;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts.Effects
{
  public class InvisibilityEffect : Effect, ITimedEffect, IPotionEffect
  {
    public double Time { get; set; }

    public override string Description => $"You become invisible for {Time}sec";
    public override Effect Copy => new InvisibilityEffect(Time);
    public string Use => Description;
    
    public InvisibilityEffect(double time)
    {
      Time = time;
    }
    
    public override void Apply(Dictionary<Type, Effect> potionEffects)
    {
      if (potionEffects[Type].FinalEffect is InvisibilityEffect effect)
        effect.Time += Time;
    }
  }
}