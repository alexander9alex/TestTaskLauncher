using CodeBase.Launcher.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
   class StaticDataService : IStaticData
   {
      private const string LauncherMenuDataPath = "StaticData/Launcher/MenuData";
      private const string ClickerMenuDataPath = "StaticData/Clicker/MenuData";

      public MenuData GetLauncherMenuData() =>
         Resources.Load<MenuData>(LauncherMenuDataPath);

      public Clicker.StaticData.MenuData GetClickerMenuData() =>
         Resources.Load<Clicker.StaticData.MenuData>(ClickerMenuDataPath);
   }
}