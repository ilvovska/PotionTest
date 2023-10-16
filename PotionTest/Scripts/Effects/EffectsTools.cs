using PotionTest.Scripts.Effects.Base;

namespace PotionTest.Scripts.Effects
{
  public static class EffectsTools
  {
    public static T GetEffectByType<T>(Effect parentEffect)where T:Effect
    {
      while (true)
      {
        if (parentEffect is IEffectEffect effect)
        {
          if (effect is T typeEffect)
            return typeEffect;
          
          parentEffect = effect.Effect;
        }
        else
          break;
      }

      return null;
    }
  }
}