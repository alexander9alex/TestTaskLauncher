using CodeBase.Runner.Data;
using UnityEngine;

namespace CodeBase.Runner.Infrastructure.Services
{
   class SaveLoadService : ISaveLoadService
   {
      private const string RunnerDataKey = "RunnerData";

      private readonly IProgressService _progressService;
      private readonly IProgressChangers _progressChangers;

      public SaveLoadService(IProgressService progressService, IProgressChangers progressChangers)
      {
         _progressService = progressService;
         _progressChangers = progressChangers;
      }

      public void SaveProgress()
      {
         foreach (ISaver saver in _progressChangers.Savers)
            saver.SaveProgress(_progressService.Progress);
         
         string progressJson = JsonUtility.ToJson(_progressService.Progress);
         PlayerPrefs.SetString(RunnerDataKey, progressJson);
      }

      public RunnerProgress LoadProgress()
      {
         string progressJson = PlayerPrefs.GetString(RunnerDataKey);
         return JsonUtility.FromJson<RunnerProgress>(progressJson);
      }
   }
}