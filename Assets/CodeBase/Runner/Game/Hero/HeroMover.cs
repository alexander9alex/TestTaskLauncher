using CodeBase.Runner.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Runner.Game.Hero
{
   internal class HeroMover : MonoBehaviour
   {
      private const float LerpRate = 0.25f;
      
      [SerializeField] private float _speed = 1;
      private CharacterController _characterController;

      public void Construct(IInputService inputService) =>
         inputService.Move += OnMove;

      private void Awake() =>
         _characterController = GetComponent<CharacterController>();

      private void OnMove(Vector3 dir)
      {
         _characterController.Move(dir * _speed);
         transform.LookAt(Vector3.Lerp(transform.position + transform.forward, transform.position + dir, LerpRate));
      }
   }
}