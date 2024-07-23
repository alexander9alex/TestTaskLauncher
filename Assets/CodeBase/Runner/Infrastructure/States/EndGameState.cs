using CodeBase.Infrastructure.States;
using CodeBase.Launcher.Infrastructure;
using CodeBase.Launcher.Infrastructure.States;
using CodeBase.Runner.Infrastructure.Services;

namespace CodeBase.Runner.Infrastructure.States
{
   internal class EndGameState : IState
   {
      private readonly ISaveLoadService _saveLoadService;
      private readonly ILauncherStateMachine _launcherStateMachine;

      public EndGameState(ISaveLoadService saveLoadService, ILauncherStateMachine launcherStateMachine)
      {
         _saveLoadService = saveLoadService;
         _launcherStateMachine = launcherStateMachine;
      }

      public void Enter()
      {
         _saveLoadService.SaveProgress();
         _launcherStateMachine.Enter<LoadMainMenuState>();
      }

      public void Exit() { }
   }
}