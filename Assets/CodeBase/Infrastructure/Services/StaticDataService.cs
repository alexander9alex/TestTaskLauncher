using CodeBase.Launcher.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
   class StaticDataService : IStaticData
   {
      private const string LauncherMenuDataPath = "StaticData/Launcher/MenuData";

      public MenuData GetLauncherMenuData() =>
         Resources.Load<MenuData>(LauncherMenuDataPath);
   }
}