using CodeBase.Game;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Runner.Infrastructure.Services;

namespace CodeBase.Runner.Infrastructure.States
{
   internal class LoadGameState : IState
   {
      private const string RunnerSceneName = "Runner";

      private readonly ICurtain _curtain;
      private readonly ISceneLoader _sceneLoader;
      private readonly IProgressChangers _progressChangers;
      private readonly IProgressService _progressService;
      private readonly IGameStateMachine _gameStateMachine;

      public LoadGameState(ICurtain curtain, ISceneLoader sceneLoader,
         IProgressChangers progressChangers, IProgressService progressService, IGameStateMachine gameStateMachine)
      {
         _curtain = curtain;
         _sceneLoader = sceneLoader;
         _progressChangers = progressChangers;
         _progressService = progressService;
         _gameStateMachine = gameStateMachine;
      }

      public void Enter() =>
         _sceneLoader.LoadScene(RunnerSceneName, OnLoaded);

      private void OnLoaded()
      {
         // init world
         
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