using CodeBase.Infrastructure.States;
using CodeBase.Runner.Infrastructure.Services;

namespace CodeBase.Runner.Infrastructure.States
{
   internal class GameLoopState : IState
   {
      private readonly IGameTimerService _gameTimerService;
      private readonly IInputService _inputService;

      public GameLoopState(IGameTimerService gameTimerService, IInputService inputService)
      {
         _gameTimerService = gameTimerService;
         _inputService = inputService;
      }

      public void Enter()
      {
         _gameTimerService.RestartTimer();
         _inputService.StartInput();
      }

      public void Exit() =>
         _inputService.StopInput();
   }
}