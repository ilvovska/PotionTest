using System;
using System.Collections.Generic;
using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts.Effects
{
  public class HealingEffect : Effect, IModifierEffect, IPotionEffect
  {
    public double Modifier { get; set; }
    
    public override string Description => $"You {(Modifier > 0 ? "heal" : "lose")} {Math.Abs(Modifier)} HP";
    public override Effect Copy => new HealingEffect(Modifier);
    public string Use => Description;
    
    
    public HealingEffect(double modifier)
    {
      Modifier = modifier;
    }
    
    public override void Apply(Dictionary<Type, Effect> potionEffects)
    {
      if (potionEffects[Type].FinalEffect is HealingEffect effect)
        effect.Modifier += Modifier;
    }
  }
}