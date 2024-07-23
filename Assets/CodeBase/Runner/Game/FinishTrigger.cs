using System;
using CodeBase.Runner.Game.Hero;
using UnityEngine;

namespace CodeBase.Runner.Game
{
   internal class FinishTrigger : MonoBehaviour
   {
      private Action _onFinished;
      private bool _finished;

      public void Construct(Action onFinished) =>
         _onFinished = onFinished;

      private void OnTriggerEnter(Collider other)
      {
         if (_finished)
            return;

         if (other.TryGetComponent<HeroMover>(out _))
         {
            _finished = true;
            _onFinished?.Invoke();
         }
      }
   }
}