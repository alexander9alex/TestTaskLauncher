using CodeBase.Clicker.Infrastructure.Services;
using CodeBase.Clicker.Infrastructure.States;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using Zenject;

namespace CodeBase.Clicker.Infrastructure.Factories
{
   internal class ClickerGameFactory : IGameFactory
   {
      private readonly DiContainer _container;
      public ClickerGameFactory(DiContainer container) =>
         _container = container;

      public void InstallBindings()
      {
         BindInfrastructure();
         BindGameStateMachine();
      }

      public void CleanUp()
      {
         UnbindInfrastructure();
         UnbindGameStateMachine();
      }

      public IGameStateMachine CreateGameStateMachine() =>
         _container.Resolve<IGameStateMachine>();

      private void BindInfrastructure()
      {
         _container.BindInterfacesAndSelfTo<ProgressService>().AsCached();
         _container.BindInterfacesAndSelfTo<SaveLoadService>().AsCached();
         _container.BindInterfacesAndSelfTo<ProgressChangers>().AsCached();
         _container.BindInterfacesAndSelfTo<ClickerStaticData>().AsCached();
         _container.BindInterfacesAndSelfTo<ClickerUiFactory>().AsCached();
      }

      private void BindGameStateMachine()
      {
         _container.BindInterfacesAndSelfTo<LoadProgressState>().AsCached();
         _container.BindInterfacesAndSelfTo<LoadGameState>().AsCached();
         _container.BindInterfacesAndSelfTo<GameLoopState>().AsCached();
         _container.BindInterfacesAndSelfTo<EndGameState>().AsCached();

         _container.BindInterfacesAndSelfTo<ClickerStateMachine>().AsCached();
      }

      private void UnbindInfrastructure()
      {
         _container.UnbindInterfacesTo<ClickerUiFactory>();
         _container.UnbindInterfacesTo<ProgressService>();
         _container.UnbindInterfacesTo<SaveLoadService>();
         _container.UnbindInterfacesTo<ProgressChangers>();
         _container.UnbindInterfacesTo<ClickerStaticData>();
      }

      private void UnbindGameStateMachine()
      {
         _container.Unbind<LoadProgressState>();
         _container.Unbind<LoadGameState>();
         _container.Unbind<GameLoopState>();
         _container.Unbind<EndGameState>();

         _container.UnbindInterfacesTo<ClickerStateMachine>();
      }
   }
}