using CodeBase.Runner.Data;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal interface IProgressService
   {
      public RunnerProgress Progress { get; set; }
   }
}