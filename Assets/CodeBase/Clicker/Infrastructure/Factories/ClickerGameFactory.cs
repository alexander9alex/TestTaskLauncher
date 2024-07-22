using CodeBase.Clicker.Infrastructure.States;
using CodeBase.Infrastructure;
using Zenject;

namespace CodeBase.Clicker.Infrastructure.Factories
{
   internal class ClickerGameFactory : IGameFactory
   {
      private readonly DiContainer _container;
      public ClickerGameFactory(DiContainer container)
      {
         _container = container;
      }

      public void InstallBindings()
      {
         BindInfrastructure();
         BindGameStateMachine();
      }

      public void CleanUp()
      {
         UnbindGameStateMachine();
         UnbindInfrastructure();
      }

      public IGameStateMachine CreateGameStateMachine() =>
         _container.Resolve<IGameStateMachine>();

      private void BindInfrastructure()
      {
         _container.BindInterfacesAndSelfTo<ClickerUiFactory>().AsCached();
      }

      private void BindGameStateMachine()
      {
         _container.BindInterfacesAndSelfTo<LoadProgressState>().AsCached();
         _container.BindInterfacesAndSelfTo<LoadGameState>().AsCached();

         _container.BindInterfacesAndSelfTo<ClickerStateMachine>().AsCached();
      }

      private void UnbindGameStateMachine()
      {
         _container.Unbind<LoadProgressState>();
         _container.Unbind<LoadGameState>();

         _container.UnbindInterfacesTo<ClickerStateMachine>();
      }

      private void UnbindInfrastructure()
      {
         _container.UnbindInterfacesTo<ClickerUiFactory>();
      }
   }
}