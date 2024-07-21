using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factories;
using Zenject;

namespace CodeBase.Infrastructure.States
{
   public abstract class StateMachine : IStateMachine, IInitializable
   {
      protected readonly IStateFactory _stateFactory;
      
      protected Dictionary<Type, IExitableState> _states;
      private IExitableState _currentState;
      
      protected StateMachine(IStateFactory stateFactory) =>
         _stateFactory = stateFactory;

      public abstract void Initialize();
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