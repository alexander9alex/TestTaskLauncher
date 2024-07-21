using CodeBase.Clicker.Infrastructure.States;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using UnityEngine;

namespace CodeBase.Clicker.Infrastructure
{
   public class ClickerStateMachine : StateMachine, IGameStateMachine
   {
      public ClickerStateMachine(IStateFactory stateFactory) : base(stateFactory) { }

      public void Initialize()
      {
         _states = new()
         {
            { typeof(LoadProgressState), _stateFactory.CreateState<LoadProgressState>() },
            { typeof(LoadGameState), _stateFactory.CreateState<LoadGameState>() },
         };
      }

      public void StartGame() =>
         Enter<LoadProgressState>();
   }
}