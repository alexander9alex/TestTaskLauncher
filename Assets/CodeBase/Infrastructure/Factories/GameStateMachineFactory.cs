using System;
using CodeBase.Data;
using CodeBase.Clicker.Infrastructure.Factories;
using CodeBase.Runner.Infrastructure.Factories;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
   class GameStateMachineFactory : IGameStateMachineFactory
   {
      private readonly DiContainer _container;

      private IGameFactory _currentGameFactory;

      public GameStateMachineFactory(DiContainer container) =>
         _container = container;

      public void CleanUp()
      {
         _currentGameFactory.CleanUp();
         _currentGameFactory = null;
      }

      public IGameStateMachine CreateGameStateMachine(GameType gameType)
      {
         switch (gameType)
         {
            case GameType.Clicker:
               _currentGameFactory = new ClickerGameFactory(_container);
               break;
            case GameType.Runner:
               _currentGameFactory = new RunnerGameFactory(_container);
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null);
         }

         _currentGameFactory.InstallBindings();
         return _currentGameFactory.CreateGameStateMachine();
      }
   }
}