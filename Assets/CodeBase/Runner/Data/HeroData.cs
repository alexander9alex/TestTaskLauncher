using UnityEngine;

namespace CodeBase.Runner.Data
{
   [CreateAssetMenu(menuName = "Static Data/Runner/HeroData", fileName = "HeroData", order = 0)]
   internal class HeroData : ScriptableObject
   {
      public GameObject Hero;
   }
}