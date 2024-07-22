using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Services;
using CodeBase.Runner.Infrastructure.Services;
using CodeBase.Runner.Infrastructure.States;
using Zenject;

namespace CodeBase.Runner.Infrastructure.Factories
{
   internal class RunnerGameFactory : IGameFactory
   {
      private readonly DiContainer _container;
      public RunnerGameFactory(DiContainer container) =>
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
      }

      private void BindGameStateMachine()
      {
         _container.BindInterfacesAndSelfTo<LoadProgressState>().AsCached();
         _container.BindInterfacesAndSelfTo<LoadGameState>().AsCached();
         _container.BindInterfacesAndSelfTo<GameLoopState>().AsCached();
         _container.BindInterfacesAndSelfTo<EndGameState>().AsCached();

         _container.BindInterfacesAndSelfTo<RunnerStateMachine>().AsCached();
      }

      private void UnbindInfrastructure()
      {
         _container.UnbindInterfacesTo<ProgressService>();
         _container.UnbindInterfacesTo<SaveLoadService>();
         _container.UnbindInterfacesTo<ProgressChangers>();
      }

      private void UnbindGameStateMachine()
      {
         _container.Unbind<LoadProgressState>();
         _container.Unbind<LoadGameState>();
         _container.Unbind<GameLoopState>();
         _container.Unbind<EndGameState>();

         _container.UnbindInterfacesTo<RunnerStateMachine>();
      }
   }
}