using CodeBase.Launcher.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
   class LauncherStaticDataService : ILauncherStaticData
   {
      private const string LauncherMenuDataPath = "StaticData/Launcher/MenuData";

      public MenuData GetLauncherMenuData() =>
         Resources.Load<MenuData>(LauncherMenuDataPath);
   }
}