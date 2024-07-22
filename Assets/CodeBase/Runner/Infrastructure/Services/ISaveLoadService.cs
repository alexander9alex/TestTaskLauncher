using CodeBase.Runner.Data;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal interface ISaveLoadService
   {
      RunnerProgress LoadProgress();
      void SaveProgress();
   }
}