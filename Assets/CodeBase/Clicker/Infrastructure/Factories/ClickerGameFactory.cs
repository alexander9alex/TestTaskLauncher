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
         _container.BindInterfacesAndSelfTo<ClickerUiFactory>().AsSingle();
      }

      private void BindGameStateMachine()
      {
         _container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
         _container.BindInterfacesAndSelfTo<LoadGameState>().AsSingle();

         _container.BindInterfacesAndSelfTo<ClickerStateMachine>().AsSingle();
      }

      private void UnbindGameStateMachine()
      {
         _container.Unbind<LoadProgressState>();
         _container.Unbind<LoadGameState>();

         _container.Unbind<ClickerStateMachine>();
      }

      private void UnbindInfrastructure()
      {
         _container.Unbind<ClickerUiFactory>();
      }
   }
}