using System;

namespace CodeBase.Infrastructure.Services
{
   public interface ISceneLoader
   {
      public void LoadScene(string name, Action onLoaded = null);
   }
}