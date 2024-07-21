using CodeBase.Game;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;

namespace CodeBase.Clicker.Infrastructure.States
{
   internal class LoadProgressState : IState
   {
      private readonly ICurtain _curtain;
      private readonly IGameStateMachine _gameStateMachine;

      public LoadProgressState(ICurtain curtain, IGameStateMachine gameStateMachine)
      {
         _curtain = curtain;
         _gameStateMachine = gameStateMachine;
      }

      public void Enter()
      {
         _curtain.Show(OnShowed);
      }

      private void OnShowed()
      {
         // loading progress...

         _gameStateMachine.Enter<LoadGameState>();
      }

      public void Exit()
      {
         
      }
   }
}