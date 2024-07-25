using System.Threading.Tasks;
using CodeBase.Clicker.Data;
using CodeBase.Clicker.Infrastructure.Services;
using CodeBase.Clicker.UI;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Clicker.Infrastructure
{
   class ClickerUiFactory : IClickerUiFactory
   {
      private readonly IProgressChangers _progressChangers;
      private readonly IGameStateMachine _gameStateMachine;
      private readonly IClickerAssets _assets;

      public ClickerUiFactory(IProgressChangers progressChangers, IGameStateMachine gameStateMachine, IClickerAssets assets)
      {
         _progressChangers = progressChangers;
         _gameStateMachine = gameStateMachine;
         _assets = assets;
      }

      public async Task CreateClickerMenu()
      {
         GameObject prefab = await _assets.Load<GameObject>(ClickerAssetAddress.ClickerMenu);

         ClickerMenuView clickerMenuView = Object.Instantiate(prefab).GetComponent<ClickerMenuView>();

         ClickerMenuModel clickerMenuModel = new ClickerMenuModel(_gameStateMachine);
         clickerMenuView.Construct(clickerMenuModel);

         _progressChangers.Register(clickerMenuModel);
      }
   }
}