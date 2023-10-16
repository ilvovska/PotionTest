using System;
using System.Collections.Generic;

namespace PotionTest.Scripts.Effects.Base
{
  public abstract class Effect
  {
    public abstract string Description { get; }
    public abstract Effect Copy { get; }
    public virtual Type Type => GetType();
    public virtual Effect FinalEffect => this;
    public virtual Effect FinalEffectWithAllEffects => this;

    public abstract void Apply(Dictionary<Type, Effect> potionEffects);
  }
}