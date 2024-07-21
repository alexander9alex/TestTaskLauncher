using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;

namespace CodeBase.Launcher.Infrastructure
{
   public class LauncherStateMachine : StateMachine, ILauncherStateMachine
   {
      public LauncherStateMachine(IStateFactory stateFactory) : base(stateFactory) { }

      public override void Initialize()
      {
         _states = new()
         {
            { typeof(BootstrapState), _stateFactory.CreateState<BootstrapState>() },
            { typeof(LoadMainMenuState), _stateFactory.CreateState<LoadMainMenuState>() },
            { typeof(LoadGameState), _stateFactory.CreateState<LoadGameState>() },
         };
         
         Enter<BootstrapState>();
      }
   }
}