using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services
{
   public class SceneLoader : ISceneLoader
   {
      private readonly ICoroutineRunner _coroutineRunner;

      public SceneLoader(ICoroutineRunner coroutineRunner)
      {
         _coroutineRunner = coroutineRunner;
      }

      public void LoadScene(string name, Action onLoaded = null)
      {
         if (SceneManager.GetActiveScene().name == name)
         {
            onLoaded?.Invoke();
            return;
         }

         LoadSceneForced(name, onLoaded);
      }

      public void LoadSceneForced(string name, Action onLoaded = null) =>
         _coroutineRunner.StartCoroutine(StartLoadSceneCoroutine(name, onLoaded));

      private IEnumerator StartLoadSceneCoroutine(string name, Action onLoaded)
      {
         AsyncOperation waitSceneLoad = SceneManager.LoadSceneAsync(name);

         while (!waitSceneLoad.isDone)
            yield return null;

         onLoaded?.Invoke();
      }
   }
}