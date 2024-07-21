using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Launcher.UI
{
   internal class MainMenuView : MonoBehaviour
   {
      [SerializeField] private Button _startClicker;
      [SerializeField] private Button _loadClickerData;
      [SerializeField] private Button _unloadClickerData;

      [SerializeField] private Button _startRunner;
      [SerializeField] private Button _loadRunnerData;
      [SerializeField] private Button _unloadRunnerData;

      public void Construct(MainMenuModel mainMenuModel)
      {
         _startClicker.onClick.AddListener(mainMenuModel.StartClicker);
         _loadClickerData.onClick.AddListener(mainMenuModel.LoadClickerData);
         _unloadClickerData.onClick.AddListener(mainMenuModel.UnloadClickerData);
         
         _startRunner.onClick.AddListener(mainMenuModel.StartRunner);
         _loadRunnerData.onClick.AddListener(mainMenuModel.LoadRunnerData);
         _unloadRunnerData.onClick.AddListener(mainMenuModel.UnloadRunnerData);
      }
   }
}