using CodeBase.Clicker.StaticData;
using CodeBase.Clicker.UI;
using CodeBase.Infrastructure.Services;
using CodeBase.Launcher.Infrastructure;
using UnityEngine;

namespace CodeBase.Clicker.Infrastructure
{
   class ClickerUiFactory : IClickerUiFactory
   {
      private readonly MenuData _menuData;
      private readonly ILauncherStateMachine _launcherStateMachine;

      public ClickerUiFactory(IStaticData staticData, ILauncherStateMachine launcherStateMachine)
      {
         _launcherStateMachine = launcherStateMachine;
         _menuData = staticData.GetClickerMenuData();
      }

      public void CreateClickerMenu()
      {
         ClickerMenuView clickerMenuView = Object.Instantiate(_menuData.ClickerMenu).GetComponent<ClickerMenuView>();
         
         ClickerMenuModel clickerMenuModel = new ClickerMenuModel(_launcherStateMachine);
         clickerMenuView.Construct(clickerMenuModel);
      }
   }
}