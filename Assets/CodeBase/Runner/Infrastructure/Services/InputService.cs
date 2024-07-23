using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal class InputService : IInputService, ITickable
   {
      private const string HorizontalAxisName = "Horizontal";
      private const string VerticalAxisName = "Vertical";

      public event Action<Vector3> Move;

      private bool _started = true;

      public void StartInput() =>
         _started = true;

      public void StopInput()
      {
         _started = false;
         Move?.Invoke(Vector3.zero);
      }

      public void Tick() =>
         TryMove();

      public void CleanUp() =>
         Move = null;

      private void TryMove()
      {
         if (!_started)
            return;
         
         Vector3 moveDir = new Vector3();

         if (Input.GetAxisRaw(HorizontalAxisName) != 0)
            moveDir.z = Input.GetAxis(HorizontalAxisName);

         if (Input.GetAxisRaw(VerticalAxisName) != 0)
            moveDir.x = -Input.GetAxis(VerticalAxisName);

         Move?.Invoke(moveDir.normalized);
      }
   }
}