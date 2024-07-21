using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using CodeBase.Launcher.Infrastructure.States;
using Zenject;

namespace CodeBase.Launcher.Infrastructure
{
   public class LauncherStateMachine : StateMachine, ILauncherStateMachine, IInitializable
   {
      public LauncherStateMachine(IStateFactory stateFactory) : base(stateFactory) { }

      public void Initialize()
      {
         _states = new()
         {
            { typeof(LauncherBootstrapState), _stateFactory.CreateState<LauncherBootstrapState>() },
            { typeof(LoadMainMenuState), _stateFactory.CreateState<LoadMainMenuState>() },
            { typeof(LoadGameState), _stateFactory.CreateState<LoadGameState>() },
         };
         
         Enter<LauncherBootstrapState>();
      }
   }
}