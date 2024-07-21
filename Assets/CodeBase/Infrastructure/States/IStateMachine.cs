﻿namespace CodeBase.Infrastructure.States
{
   public interface IStateMachine
   {
      public void Enter<TState>() where TState : class, IState;
      public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
   }
}