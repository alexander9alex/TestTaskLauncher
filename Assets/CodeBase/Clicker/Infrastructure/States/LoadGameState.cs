using CodeBase.Game;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.Clicker.Infrastructure.States
{
   public class LoadGameState : IState
   {
      private const string ClickerSceneName = "Clicker";
      
      private readonly ICurtain _curtain;
      private readonly ISceneLoader _sceneLoader;
      private readonly IClickerUiFactory _clickerUiFactory;

      public LoadGameState(ICurtain curtain, ISceneLoader sceneLoader, IClickerUiFactory clickerUiFactory)
      {
         _curtain = curtain;
         _sceneLoader = sceneLoader;
         _clickerUiFactory = clickerUiFactory;
      }

      public void Enter()
      {
         _sceneLoader.LoadScene(ClickerSceneName, OnLoaded);
      }

      private void OnLoaded()
      {
         _clickerUiFactory.CreateClickerMenu();
         
         _curtain.Hide();
      }

      public void Exit() { }
   }
}