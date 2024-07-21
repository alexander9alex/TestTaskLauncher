using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.Launcher.Infrastructure
{
   public class BootstrapState : IState
   {
      private const string BootSceneName = "Boot";

      private readonly ISceneLoader _sceneLoader;
      private readonly ILauncherStateMachine _launcherStateMachine;

      public BootstrapState(ISceneLoader sceneLoader, ILauncherStateMachine launcherStateMachine)
      {
         _sceneLoader = sceneLoader;
         _launcherStateMachine = launcherStateMachine;
      }

      public void Enter() =>
         _sceneLoader.LoadScene(BootSceneName, OnLoaded);

      private void OnLoaded() =>
         _launcherStateMachine.Enter<LoadMainMenuState>();

      public void Exit() { }
   }
}