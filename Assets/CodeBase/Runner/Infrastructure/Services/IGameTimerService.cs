namespace CodeBase.Runner.Infrastructure.Services
{
   internal interface IGameTimerService
   {
      public void RestartTimer();
      public float StopTimer();
   }
}