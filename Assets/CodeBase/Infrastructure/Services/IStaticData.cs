using CodeBase.Launcher.StaticData;

namespace CodeBase.Infrastructure.Services
{
   internal interface IStaticData
   {
      MenuData GetLauncherMenuData();
      Clicker.StaticData.MenuData GetClickerMenuData();
   }
}