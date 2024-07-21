using CodeBase.Data;

namespace CodeBase.Infrastructure.Factories
{
   public interface IGameStateMachineFactory
   {
      void CleanUp();
      IGameStateMachine CreateGameStateMachine(GameType gameType);
   }
}