using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Runner.Infrastructure.States;

namespace CodeBase.Runner.Infrastructure
{
   internal class RunnerStateMachine : StateMachine, IGameStateMachine
   {
      public RunnerStateMachine(IStateFactory stateFactory) : base(stateFactory) { }

      public void Initialize()
      {
         _states = new()
         {
         { typeof(LoadProgressState), _stateFactory.CreateState<LoadProgressState>() },
         { typeof(LoadGameState), _stateFactory.CreateState<LoadGameState>() },
         { typeof(GameLoopState), _stateFactory.CreateState<GameLoopState>() },
         { typeof(EndGameState), _stateFactory.CreateState<EndGameState>() },
         };
}

      public void StartGame() =>
         Enter<LoadProgressState>();
   }
}