namespace CodeBase.Infrastructure
{
   public interface IGameStateMachine : IStateMachine
   {
      void Initialize();
      void StartGame();
   }
}