using System;
using System.Collections.Generic;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts.Effects
{
  public class AttackSpeedEffect : Effect, ITimedEffect, IModifierEffect, IPotionEffect
  {
    public double Modifier { get; set; }
    public double Time { get; set; }
    
    public override string Description => $"You get {Modifier}% attack speed for {Time}sec";
    public override Effect Copy => new AttackSpeedEffect(Modifier, Time);

    public string Use => Description;

    public AttackSpeedEffect(double modifier, double time)
    {
      Modifier = modifier;
      Time = time;
    }
    
    public override void Apply(Dictionary<Type, Effect> potionEffects)
    {
      if (potionEffects[Type].FinalEffect is AttackSpeedEffect effect)
      {
        effect.Modifier += Modifier;
        effect.Time = Math.Max(Time, effect.Time);
      }
    }
  }
}