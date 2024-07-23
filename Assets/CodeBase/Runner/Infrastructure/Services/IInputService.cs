using System;
using UnityEngine;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal interface IInputService
   {
      void StartInput();
      void StopInput();
      event Action<Vector3> Move;
      void CleanUp();
   }
}