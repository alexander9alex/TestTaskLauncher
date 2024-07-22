namespace CodeBase.Infrastructure.Factories
{
   internal interface IGameFactory
   {
      void InstallBindings();
      void CleanUp();
      IGameStateMachine CreateGameStateMachine();
   }
}