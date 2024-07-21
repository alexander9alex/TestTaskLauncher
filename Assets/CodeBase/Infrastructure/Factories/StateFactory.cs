using CodeBase.Infrastructure.States;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
   class StateFactory : IStateFactory
   {
      private readonly DiContainer _container;
      public StateFactory(DiContainer container)
      {
         _container = container;
      }

      public TState CreateState<TState>() where TState : IExitableState =>
         _container.Resolve<TState>();
   }
}