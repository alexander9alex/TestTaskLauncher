using CodeBase.Data;
using CodeBase.Game;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;

namespace CodeBase.Launcher.Infrastructure.States
{
   public class LoadGameState : IPayloadedState<GameType>
   {
      private readonly IGameStateMachineFactory _gameStateMachineFactory;
      private readonly ICurtain _curtain;

      public LoadGameState(IGameStateMachineFactory gameStateMachineFactory, ICurtain curtain)
      {
         _gameStateMachineFactory = gameStateMachineFactory;
         _curtain = curtain;
      }

      public void Enter(GameType gameType)
      {
         IGameStateMachine gameStateMachine = _gameStateMachineFactory.CreateGameStateMachine(gameType);
         gameStateMachine.Initialize();
         gameStateMachine.StartGame();
      }
      
      public void Exit() =>
         _gameStateMachineFactory.CleanUp();
   }
}