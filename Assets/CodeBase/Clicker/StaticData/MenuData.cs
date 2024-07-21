using UnityEngine;

namespace CodeBase.Clicker.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Clicker/Menu Data", fileName = "MenuData", order = 0)]
   public class MenuData : ScriptableObject
   {
      public GameObject ClickerMenu;
   }
}