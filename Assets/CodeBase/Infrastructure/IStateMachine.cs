﻿using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure
{
   public interface IStateMachine
   {
      public void Enter<TState>() where TState : class, IState;
      public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
   }
}