using CodeBase.Game;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Runner.Infrastructure.Factories;
using CodeBase.Runner.Infrastructure.Services;
using UnityEngine.SceneManagement;

namespace CodeBase.Runner.Infrastructure.States
{
   internal class RestartGameState : IState
   {
      private readonly ICurtain _curtain;
      private readonly ISceneLoader _sceneLoader;
      private readonly IGameStateMachine _gameStateMachine;
      private readonly IProgressChangers _progressChangers;
      private readonly ILocationFactory _locationFactory;
      private readonly IHeroFactory _heroFactory;
      private readonly IRunnerUiFactory _uiFactory;
      private readonly IInputService _inputService;

      public RestartGameState(ICurtain curtain, ISceneLoader sceneLoader, IGameStateMachine gameStateMachine,
         IProgressChangers progressChangers, ILocationFactory locationFactory, IHeroFactory heroFactory, IRunnerUiFactory uiFactory,
         IInputService inputService)
      {
         _curtain = curtain;
         _sceneLoader = sceneLoader;
         _gameStateMachine = gameStateMachine;
         _progressChangers = progressChangers;
         _locationFactory = locationFactory;
         _heroFactory = heroFactory;
         _uiFactory = uiFactory;
         _inputService = inputService;
      }

      public void Enter()
      {
         _curtain.Show(OnEnded);
      }

      private void OnEnded()
      {
         CleanUp();

         _sceneLoader.LoadSceneForced(SceneManager.GetActiveScene().name, OnLoaded);
      }

      private void CleanUp()
      {
         _progressChangers.CleanUp();
         _locationFactory.CleanUp();
         _heroFactory.CleanUp();
         _uiFactory.CleanUp();
         _inputService.CleanUp();
      }

      private void OnLoaded() =>
         _gameStateMachine.Enter<LoadGameState>();

      public void Exit() { }
   }
}