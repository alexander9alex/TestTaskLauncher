using System;

namespace CodeBase.Infrastructure.Services
{
   public interface ISceneLoader
   {
      public void LoadScene(string name, Action onLoaded = null);
      void LoadSceneForced(string name, Action onLoaded = null);
   }
}