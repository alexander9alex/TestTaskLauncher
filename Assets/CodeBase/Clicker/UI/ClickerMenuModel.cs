using System;
using CodeBase.Launcher.Infrastructure;
using CodeBase.Launcher.Infrastructure.States;

namespace CodeBase.Clicker.UI
{
   public class ClickerMenuModel
   {
      public event Action<int> ScoreChanged;
      private int _score;
      private readonly ILauncherStateMachine _launcherStateMachine;
      public ClickerMenuModel(ILauncherStateMachine launcherStateMachine)
      {
         _launcherStateMachine = launcherStateMachine;
      }

      public void AddScore()
      {
         _score++;
         ScoreChanged?.Invoke(_score);
      }

      public void CloseGame()
      {
         _launcherStateMachine.Enter<LoadMainMenuState>();
      }
   }
}