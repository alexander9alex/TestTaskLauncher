using CodeBase.Clicker.Infrastructure.Services;
using CodeBase.Clicker.StaticData;
using CodeBase.Clicker.UI;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Clicker.Infrastructure
{
   class ClickerUiFactory : IClickerUiFactory
   {
      private readonly MenuData _menuData;
      private readonly IProgressChangers _progressChangers;
      private readonly IGameStateMachine _gameStateMachine;

      public ClickerUiFactory(IStaticData staticData, IProgressChangers progressChangers, IGameStateMachine gameStateMachine)
      {
         _progressChangers = progressChangers;
         _gameStateMachine = gameStateMachine;
         _menuData = staticData.GetClickerMenuData();
      }

      public void CreateClickerMenu()
      {
         ClickerMenuView clickerMenuView = Object.Instantiate(_menuData.ClickerMenu).GetComponent<ClickerMenuView>();

         ClickerMenuModel clickerMenuModel = new ClickerMenuModel(_gameStateMachine);
         clickerMenuView.Construct(clickerMenuModel);

         _progressChangers.Register(clickerMenuModel);
      }
   }
}