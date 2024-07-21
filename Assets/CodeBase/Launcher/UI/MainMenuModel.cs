using CodeBase.Data;
using CodeBase.Launcher.Infrastructure;
using CodeBase.Launcher.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Launcher.UI
{
   public class MainMenuModel
   {
      private readonly ILauncherStateMachine _launcherStateMachine;

      public MainMenuModel(ILauncherStateMachine launcherStateMachine)
      {
         _launcherStateMachine = launcherStateMachine;
      }

      public void StartClicker() =>
         _launcherStateMachine.Enter<LoadGameState, GameType>(GameType.Clicker);

      public void LoadClickerData() =>
         Debug.Log("Clicker data is loaded!");

      public void UnloadClickerData() =>
         Debug.Log("Clicker data is unloaded!");

      public void StartRunner() =>
         _launcherStateMachine.Enter<LoadGameState, GameType>(GameType.Runner);

      public void LoadRunnerData() =>
         Debug.Log("Runner data is loaded!");

      public void UnloadRunnerData() =>
         Debug.Log("Runner data is unloaded!");
   }
}