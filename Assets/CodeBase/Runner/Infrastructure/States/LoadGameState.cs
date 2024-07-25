using System.Threading.Tasks;
using CodeBase.Game;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Runner.Infrastructure.Factories;
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
      private IRunnerStaticData _launcherStaticData;
      private readonly ILocationFactory _locationFactory;
      private readonly IHeroFactory _heroFactory;

      public LoadGameState(ICurtain curtain, ISceneLoader sceneLoader, IProgressChangers progressChangers, IProgressService progressService,
         IGameStateMachine gameStateMachine, ILocationFactory locationFactory, IHeroFactory heroFactory)
      {
         _curtain = curtain;
         _sceneLoader = sceneLoader;
         _progressChangers = progressChangers;
         _progressService = progressService;
         _gameStateMachine = gameStateMachine;
         _locationFactory = locationFactory;
         _heroFactory = heroFactory;
      }

      public void Enter() =>
         _sceneLoader.LoadScene(RunnerSceneName, OnLoaded);

      private async void OnLoaded()
      {
         await InitWorld();
         LoadProgress();

         _curtain.Hide();
         _gameStateMachine.Enter<GameLoopState>();
      }

      private async Task InitWorld()
      {
         await _locationFactory.CreateRunnerLocation();
         await _heroFactory.CreateHero();
      }

      private void LoadProgress()
      {
         foreach (ILoader loader in _progressChangers.Loaders)
            loader.LoadProgress(_progressService.Progress);
      }

      public void Exit() { }
   }
}