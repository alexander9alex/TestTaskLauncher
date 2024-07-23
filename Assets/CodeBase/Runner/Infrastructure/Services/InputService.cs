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

      public void Tick() =>
         TryMove();

      private void TryMove()
      {
         Vector3 moveDir = new Vector3();

         if (Input.GetAxisRaw(HorizontalAxisName) != 0)
            moveDir.z = Input.GetAxis(HorizontalAxisName);

         if (Input.GetAxisRaw(VerticalAxisName) != 0)
            moveDir.x = -Input.GetAxis(VerticalAxisName);

         Move?.Invoke(moveDir.normalized);
      }
   }
}