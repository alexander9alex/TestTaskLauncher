using CodeBase.Game;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using CodeBase.Runner.Infrastructure.Services;

namespace CodeBase.Runner.Infrastructure.States
{
   internal class LoadProgressState : IState
   {
      private readonly ICurtain _curtain;
      private readonly IGameStateMachine _gameStateMachine;
      private readonly IProgressService _progressService;
      private readonly ISaveLoadService _saveLoadService;

      public LoadProgressState(ICurtain curtain, IGameStateMachine gameStateMachine, IProgressService progressService,
         ISaveLoadService saveLoadService)
      {
         _curtain = curtain;
         _gameStateMachine = gameStateMachine;
         _progressService = progressService;
         _saveLoadService = saveLoadService;
      }

      public void Enter() =>
         _curtain.Show(OnShowed);

      private void OnShowed()
      {
         _progressService.Progress = _saveLoadService.LoadProgress() ?? new();

         _gameStateMachine.Enter<LoadGameState>();
      }

      public void Exit() { }
   }
}