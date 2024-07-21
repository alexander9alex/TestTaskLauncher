using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure.Factories
{
   public interface IStateFactory
   {
      TState CreateState<TState>() where TState : IExitableState;
   }
}