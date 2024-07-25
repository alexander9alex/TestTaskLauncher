using System;
using CodeBase.Clicker.Data;
using CodeBase.Clicker.Infrastructure.Services;
using CodeBase.Clicker.Infrastructure.States;
using CodeBase.Infrastructure;

namespace CodeBase.Clicker.UI
{
   public class ClickerMenuModel : ISaver, ILoader
   {
      public event Action<int> ScoreChanged;
      private int _score;
      private readonly IGameStateMachine _gameStateMachine;

      public ClickerMenuModel(IGameStateMachine gameStateMachine)
      {
         _gameStateMachine = gameStateMachine;
      }

      public void AddScore()
      {
         _score++;
         ScoreChanged?.Invoke(_score);
      }

      public void CloseGame() =>
         _gameStateMachine.Enter<EndGameState>();

      public void LoadProgress(ClickerProgress progress)
      {
         _score = progress.Score;
         ScoreChanged?.Invoke(_score);
      }

      public void SaveProgress(ClickerProgress progress) =>
         progress.Score = _score;
   }
}