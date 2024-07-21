using CodeBase.Infrastructure;

namespace CodeBase.Clicker.Infrastructure.Factories
{
   internal interface IGameFactory
   {
      void InstallBindings();
      void CleanUp();
      IGameStateMachine CreateGameStateMachine();
   }
}