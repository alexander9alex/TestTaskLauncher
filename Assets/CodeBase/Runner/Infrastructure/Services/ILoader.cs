using CodeBase.Runner.Data;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal interface ILoader
   {
      public void LoadProgress(RunnerProgress progress);
   }
}