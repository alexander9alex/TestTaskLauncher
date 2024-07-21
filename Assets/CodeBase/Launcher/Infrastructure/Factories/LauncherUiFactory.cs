using UnityEngine;

namespace CodeBase.Launcher.Infrastructure.Factories
{
   class LauncherUiFactory : ILauncherUiFactory
   {
      public void CreateMainMenu()
      {
         Debug.Log("Main menu created...");
      }
   }
}