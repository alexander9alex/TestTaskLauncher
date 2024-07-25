using CodeBase.Clicker.Infrastructure.Services;
using CodeBase.Game;
using CodeBase.Infrastructure;
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
      private readonly IProgressChangers _progressChangers;
      private readonly IProgressService _progressService;
      private readonly IGameStateMachine _gameStateMachine;

      public LoadGameState(ICurtain curtain, ISceneLoader sceneLoader, IClickerUiFactory clickerUiFactory,
         IProgressChangers progressChangers, IProgressService progressService, IGameStateMachine gameStateMachine)
      {
         _curtain = curtain;
         _sceneLoader = sceneLoader;
         _clickerUiFactory = clickerUiFactory;
         _progressChangers = progressChangers;
         _progressService = progressService;
         _gameStateMachine = gameStateMachine;
      }

      public void Enter() =>
         _sceneLoader.LoadScene(ClickerSceneName, OnLoaded);

      private async void OnLoaded()
      {
         await _clickerUiFactory.CreateClickerMenu();
         LoadProgress();

         _curtain.Hide();
         _gameStateMachine.Enter<GameLoopState>();
      }

      private void LoadProgress()
      {
         foreach (ILoader loader in _progressChangers.Loaders)
            loader.LoadProgress(_progressService.Progress);
      }

      public void Exit() { }
   }
}