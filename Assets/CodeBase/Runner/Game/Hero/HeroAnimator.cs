using CodeBase.Runner.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Runner.Game.Hero
{
   internal class HeroAnimator : MonoBehaviour
   {
      private const string SpeedName = "Speed";
      private Animator _animator;
      
      public void Construct(IInputService inputService) =>
         inputService.Move += OnMove;

      private void Awake() =>
         _animator = GetComponent<Animator>();

      private void OnMove(Vector3 dir) =>
         _animator.SetFloat(SpeedName, dir.magnitude);
   }
}