using System.Threading.Tasks;

namespace CodeBase.Runner.Infrastructure.Factories
{
   internal interface ILocationFactory
   {
      Task CreateRunnerLocation();
      void CleanUp();
   }
}