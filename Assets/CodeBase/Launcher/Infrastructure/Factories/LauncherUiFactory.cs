using CodeBase.Infrastructure.Services;
using CodeBase.Launcher.StaticData;
using CodeBase.Launcher.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Launcher.Infrastructure.Factories
{
   class LauncherUiFactory : ILauncherUiFactory
   {
      private readonly MenuData _menuData;
      private readonly ILauncherStateMachine _launcherStateMachine;

      public LauncherUiFactory(IStaticData staticData, ILauncherStateMachine launcherStateMachine)
      {
         _launcherStateMachine = launcherStateMachine;
         _menuData = staticData.GetLauncherMenuData();
      }

      public void CreateMainMenu()
      {
         GameObject mainMenuPrefab = _menuData.MainMenu;
         MainMenuView mainMenuView = Object.Instantiate(mainMenuPrefab).GetComponent<MainMenuView>();
         MainMenuModel mainMenuModel = new MainMenuModel(_launcherStateMachine);
         mainMenuView.Construct(mainMenuModel);
      }
   }
}