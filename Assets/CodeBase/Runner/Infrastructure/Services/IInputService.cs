using System;
using UnityEngine;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal interface IInputService
   {
      public event Action<Vector3> Move;
   }
}