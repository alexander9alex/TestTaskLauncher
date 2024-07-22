using CodeBase.Game;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Launcher.Infrastructure.Factories;

namespace CodeBase.Launcher.Infrastructure.States
{
   public class LoadMainMenuState : IState
   {
      private const string LauncherSceneName = "Launcher";
      
      private readonly ICurtain _curtain;
      private readonly ILauncherUiFactory _launcherUiFactory;
      private readonly ISceneLoader _sceneLoader;

      public LoadMainMenuState(ICurtain curtain, ILauncherUiFactory launcherUiFactory, ISceneLoader sceneLoader)
      {
         _curtain = curtain;
         _launcherUiFactory = launcherUiFactory;
         _sceneLoader = sceneLoader;
      }

      public void Enter()
      {
         _curtain.Show(OnShowed);
      }

      private void OnShowed() =>
         _sceneLoader.LoadScene(LauncherSceneName, OnLoaded);

      private void OnLoaded()
      {
         _launcherUiFactory.CreateMainMenu();
         
         _curtain.Hide();
      }

      public void Exit() { }
   }
}