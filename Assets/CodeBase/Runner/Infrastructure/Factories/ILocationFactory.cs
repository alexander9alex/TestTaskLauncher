namespace CodeBase.Runner.Infrastructure.Factories
{
   internal interface ILocationFactory
   {
      void CreateRunnerLocation();
      void CleanUp();
   }
}