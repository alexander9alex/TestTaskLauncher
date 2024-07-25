using CodeBase.Clicker.Data;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Launcher.Infrastructure;
using CodeBase.Launcher.Infrastructure.States;
using CodeBase.Runner.Data;
using UnityEngine;

namespace CodeBase.Launcher.UI
{
   public class MainMenuModel
   {
      private readonly ILauncherStateMachine _launcherStateMachine;
      private readonly IClickerAssets _clickerAssets;
      private readonly IRunnerAssets _runnerAssets;

      public MainMenuModel(ILauncherStateMachine launcherStateMachine, IClickerAssets clickerAssets, IRunnerAssets runnerAssets)
      {
         _launcherStateMachine = launcherStateMachine;
         _clickerAssets = clickerAssets;
         _runnerAssets = runnerAssets;
      }

      public void StartClicker() =>
         _launcherStateMachine.Enter<LoadGameState, GameType>(GameType.Clicker);

      public async void LoadClickerData()
      {
         await _clickerAssets.Load<GameObject>(ClickerAssetAddress.ClickerMenu);
      }

      public void UnloadClickerData() =>
         _clickerAssets.CleanUp();

      public void StartRunner() =>
         _launcherStateMachine.Enter<LoadGameState, GameType>(GameType.Runner);

      public async void LoadRunnerData()
      {
         await _runnerAssets.Load<GameObject>(RunnerAssetAddress.Hero);
         await _runnerAssets.Load<GameObject>(RunnerAssetAddress.ResultMenu);
         await _runnerAssets.Load<GameObject>(RunnerAssetAddress.RunnerLocation);
         await _runnerAssets.Load<GameObject>(RunnerAssetAddress.Finish);
      }
      public void UnloadRunnerData() =>
         _runnerAssets.CleanUp();
   }
}