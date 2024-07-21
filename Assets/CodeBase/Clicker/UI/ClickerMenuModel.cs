using System;
using UnityEngine;

namespace CodeBase.Clicker.UI
{
   public class ClickerMenuModel
   {
      public event Action<int> ScoreChanged;
      private int _score;

      public void AddScore()
      {
         _score++;
         ScoreChanged?.Invoke(_score);
      }

      public void CloseGame()
      {
         Debug.Log("Game closed!");
      }
   }
}