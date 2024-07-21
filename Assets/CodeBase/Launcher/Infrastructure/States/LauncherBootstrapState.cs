using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Launcher.Infrastructure.States
{
   public class LauncherBootstrapState : IState
   {
      private const string BootSceneName = "Boot";
      private const int TargetFrameRate = 60;

      private readonly ISceneLoader _sceneLoader;
      private readonly ILauncherStateMachine _launcherStateMachine;

      public LauncherBootstrapState(ISceneLoader sceneLoader, ILauncherStateMachine launcherStateMachine)
      {
         _sceneLoader = sceneLoader;
         _launcherStateMachine = launcherStateMachine;
      }

      public void Enter()
      {
         Application.targetFrameRate = TargetFrameRate;
         _sceneLoader.LoadScene(BootSceneName, OnLoaded);
      }

      private void OnLoaded() =>
         _launcherStateMachine.Enter<LoadMainMenuState>();

      public void Exit() { }
   }
}