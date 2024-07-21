using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure
{
   public abstract class StateMachine : IStateMachine
   {
      protected readonly IStateFactory _stateFactory;
      
      protected Dictionary<Type, IExitableState> _states;
      private IExitableState _currentState;
      
      protected StateMachine(IStateFactory stateFactory) =>
         _stateFactory = stateFactory;

      public void Enter<TState>() where TState : class, IState
      {
         _currentState?.Exit();
         TState state = GetState<TState>();
         state.Enter();
         _currentState = state;
      }

      public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
      {
         _currentState?.Exit();
         TState state = GetState<TState>();
         state.Enter(payload);
         _currentState = state;
      }

      private TState GetState<TState>() where TState : class, IExitableState =>
         _states[typeof(TState)] as TState;
   }
}