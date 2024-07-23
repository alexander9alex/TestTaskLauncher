using CodeBase.Infrastructure;
using CodeBase.Runner.Game.UI;
using CodeBase.Runner.Infrastructure.Services;
using CodeBase.Runner.StaticData;
using UnityEngine;

namespace CodeBase.Runner.Infrastructure.Factories
{
   class RunnerUiFactory : IRunnerUiFactory
   {
      private readonly MenuData _menuData;
      private readonly IGameTimerService _gameTimerService;
      private readonly IInputService _inputService;
      private readonly IGameStateMachine _gameStateMachine;
      private readonly ISaveLoadService _saveLoadService;
      private readonly IProgressChangers _progressChangers;
      private readonly IProgressService _progressService;
      
      private GameObject _scoreMenu;

      public RunnerUiFactory(IRunnerStaticData staticData, IGameTimerService gameTimerService, IInputService inputService,
         IGameStateMachine gameStateMachine, ISaveLoadService saveLoadService, IProgressChangers progressChangers,
         IProgressService progressService)
      {
         _gameTimerService = gameTimerService;
         _inputService = inputService;
         _gameStateMachine = gameStateMachine;
         _saveLoadService = saveLoadService;
         _progressChangers = progressChangers;
         _progressService = progressService;
         _menuData = staticData.GetMenuData();
      }

      public void CreateScoreMenu()
      {
         _scoreMenu = Object.Instantiate(_menuData.ResultMenu);
         ResultMenuModel resultMenuModel = new ResultMenuModel(_gameTimerService, _inputService, _gameStateMachine, _saveLoadService,
            _progressService.Progress);
         _progressChangers.Register(resultMenuModel);
         resultMenuModel.Init();
         _scoreMenu.GetComponent<ResultMenuView>().Construct(resultMenuModel);
      }

      public void CleanUp() =>
         Object.Instantiate(_scoreMenu);
   }
}