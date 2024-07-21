using UnityEngine;

namespace CodeBase.Launcher.Data
{
   [CreateAssetMenu(menuName = "Static Data/Launcher/Menu Data", fileName = "MenuData", order = 0)]
   public class MenuData : ScriptableObject
   {
      public GameObject MainMenu;
   }
}