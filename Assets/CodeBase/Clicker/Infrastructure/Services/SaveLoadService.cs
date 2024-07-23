using CodeBase.Clicker.Data;
using UnityEngine;

namespace CodeBase.Clicker.Infrastructure.Services
{
   class SaveLoadService : ISaveLoadService
   {
      private const string ClickerDataKey = "ClickerData";

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
         
         string jsonProgress = JsonUtility.ToJson(_progressService.Progress);
         PlayerPrefs.SetString(ClickerDataKey, jsonProgress);
      }

      public ClickerProgress LoadProgress()
      {
         string json = PlayerPrefs.GetString(ClickerDataKey);
         return JsonUtility.FromJson<ClickerProgress>(json);
      }
   }
}