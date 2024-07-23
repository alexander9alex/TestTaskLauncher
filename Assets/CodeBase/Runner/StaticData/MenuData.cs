using UnityEngine;

namespace CodeBase.Runner.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Runner/Menu Data", fileName = "MenuData", order = 0)]
   internal class MenuData : ScriptableObject
   {
      public GameObject ResultMenu;
   }
}