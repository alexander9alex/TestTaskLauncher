using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using CodeBase.Runner.Data;
using CodeBase.Runner.Game.UI;
using CodeBase.Runner.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Runner.Infrastructure.Factories
{
   class RunnerUiFactory : IRunnerUiFactory
   {
      private readonly IGameTimerService _gameTimerService;
      private readonly IInputService _inputService;
      private readonly IGameStateMachine _gameStateMachine;
      private readonly ISaveLoadService _saveLoadService;
      private readonly IProgressChangers _progressChangers;
      private readonly IProgressService _progressService;
      private readonly IRunnerAssets _assets;
      
      private GameObject _scoreMenu;

      public RunnerUiFactory(IGameTimerService gameTimerService, IInputService inputService,
         IGameStateMachine gameStateMachine, ISaveLoadService saveLoadService, IProgressChangers progressChangers,
         IProgressService progressService, IRunnerAssets assets)
      {
         _gameTimerService = gameTimerService;
         _inputService = inputService;
         _gameStateMachine = gameStateMachine;
         _saveLoadService = saveLoadService;
         _progressChangers = progressChangers;
         _progressService = progressService;
         _assets = assets;
      }

      public async void CreateResultMenu()
      {
         GameObject resultMenuPrefab = await _assets.Load<GameObject>(RunnerAssetAddress.ResultMenu);
         _scoreMenu = Object.Instantiate(resultMenuPrefab);
         
         ResultMenuModel resultMenuModel = new ResultMenuModel(_gameTimerService, _inputService, _gameStateMachine, _saveLoadService,
            _progressService.Progress);
         _progressChangers.Register(resultMenuModel);
         resultMenuModel.Init();
         _scoreMenu.GetComponent<ResultMenuView>().Construct(resultMenuModel);
      }

      public void CleanUp() =>
         Object.Destroy(_scoreMenu);
   }
}