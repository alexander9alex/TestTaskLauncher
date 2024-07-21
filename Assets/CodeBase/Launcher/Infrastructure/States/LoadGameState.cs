using CodeBase.Data;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Launcher.Infrastructure.States
{
   public class LoadGameState : IPayloadedState<GameType>
   {
      public void Enter(GameType gameType) =>
         Debug.Log("Game loaded: " + gameType);

      public void Exit()
      {
         
      }
   }
}