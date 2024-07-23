using CodeBase.Clicker.StaticData;
using UnityEngine;

namespace CodeBase.Clicker.Infrastructure.Services
{
   class ClickerStaticData : IClickerStaticData
   {
      private const string ClickerMenuDataPath = "StaticData/Clicker/MenuData";

      public MenuData GetClickerMenuData() =>
         Resources.Load<MenuData>(ClickerMenuDataPath); 
   }
}