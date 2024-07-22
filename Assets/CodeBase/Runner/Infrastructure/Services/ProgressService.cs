using CodeBase.Runner.Data;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal class ProgressService : IProgressService
   {
      public RunnerProgress Progress { get; set; }
   }
}