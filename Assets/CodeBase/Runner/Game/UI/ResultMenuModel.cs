using CodeBase.Infrastructure;
using CodeBase.Runner.Data;
using CodeBase.Runner.Infrastructure.Services;
using CodeBase.Runner.Infrastructure.States;

namespace CodeBase.Runner.Game.UI
{
   internal class ResultMenuModel : ISaver, ILoader
   {
      public string Record => $"{_record:f3}";
      private float _record;
      public string Score => $"{_score:f3}";
      private float _score;

      private readonly IGameStateMachine _gameStateMachine;
      private readonly ISaveLoadService _saveLoadService;

      public ResultMenuModel(IGameTimerService gameTimerService, IInputService inputService, IGameStateMachine gameStateMachine,
         ISaveLoadService saveLoadService, RunnerProgress progress)
      {
         _gameStateMachine = gameStateMachine;
         _saveLoadService = saveLoadService;
         
         _record = progress.RecordTime;
         
         _score = gameTimerService.StopTimer();
         
         if (_score < _record)
            _record = _score;
         
         inputService.StopInput();
      }

      public void Init() =>
         _saveLoadService.SaveProgress();

      public void RestartGame() =>
         _gameStateMachine.Enter<RestartGameState>();

      public void EndGame() =>
         _gameStateMachine.Enter<EndGameState>();

      public void SaveProgress(RunnerProgress progress) =>
         progress.RecordTime = _record;

      public void LoadProgress(RunnerProgress progress) =>
         _record = progress.RecordTime;
   }
}