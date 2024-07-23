using CodeBase.Clicker.Infrastructure.Services;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Launcher.Infrastructure;
using CodeBase.Launcher.Infrastructure.States;

namespace CodeBase.Clicker.Infrastructure.States
{
   public class EndGameState : IState
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