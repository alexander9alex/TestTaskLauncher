using CodeBase.Launcher.Infrastructure.States;
using Zenject;

namespace CodeBase.Launcher.Infrastructure.Installers
{
   public class LauncherStateMachineInstaller : MonoInstaller
   {
      
      public override void InstallBindings()
      {
         Container.BindInterfacesAndSelfTo<LauncherBootstrapState>().AsSingle();
         Container.BindInterfacesAndSelfTo<LoadMainMenuState>().AsSingle();
         Container.BindInterfacesAndSelfTo<LoadGameState>().AsSingle();

         StartUpLauncherStateMachine();
      }

      private void StartUpLauncherStateMachine() =>
         Container.BindInterfacesAndSelfTo<LauncherStateMachine>().AsSingle();
   }
}