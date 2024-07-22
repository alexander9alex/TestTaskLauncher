using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Launcher.Infrastructure;
using CodeBase.Launcher.Infrastructure.States;

namespace CodeBase.Clicker.Infrastructure.States
{
   public class EndGameState : IState
   {
      private readonly ISaveLoadService _saveLoadService;
      private readonly IProgressChangers _progressChangers;
      private readonly ILauncherStateMachine _launcherStateMachine;

      public EndGameState(ISaveLoadService saveLoadService, IProgressChangers progressChangers, ILauncherStateMachine launcherStateMachine)
      {
         _saveLoadService = saveLoadService;
         _progressChangers = progressChangers;
         _launcherStateMachine = launcherStateMachine;
      }

      public void Enter()
      {
         _saveLoadService.SaveProgress();
         _progressChangers.CleanUp();
         
         _launcherStateMachine.Enter<LoadMainMenuState>();
      }

      public void Exit() { }
   }
}