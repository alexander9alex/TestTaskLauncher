using CodeBase.Runner.Game.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Runner.Infrastructure.Services
{
   class GameTimerService : IGameTimerService, ITickable
   {
      private float _timer;
      private bool _started;

      public void RestartTimer()
      {
         _timer = 0;
         _started = true;
      }

      public float StopTimer()
      {
         _started = false;
         return _timer;
      }

      public void Tick()
      {
         if (_started)
            _timer += Time.deltaTime;
      }
   }
}