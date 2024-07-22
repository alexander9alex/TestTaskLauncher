using CodeBase.Runner.Data;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal interface ISaver
   {
      public void SaveProgress(RunnerProgress progress);
   }
}