using CodeBase.Runner.Game;
using CodeBase.Runner.Infrastructure.Services;
using CodeBase.Runner.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Runner.Infrastructure.Factories
{
   class LocationFactory : ILocationFactory
   {
      private readonly LocationData _locationData;
      private readonly IRunnerUiFactory _runnerUiFactory;
      private Transform _runnerLocation;

      public LocationFactory(IRunnerStaticData staticData, IRunnerUiFactory runnerUiFactory)
      {
         _runnerUiFactory = runnerUiFactory;
         _locationData = staticData.GetLocationData();
      }

      public void CreateRunnerLocation()
      {
         _runnerLocation = Object.Instantiate(_locationData.RunnerLocation).transform;
         GameObject finish = Object.Instantiate(_locationData.Finish, _locationData.FinishPosition, Quaternion.identity, _runnerLocation);
         finish.GetComponent<FinishTrigger>().Construct(OnFinished);
      }

      public void CleanUp() =>
         Object.Destroy(_runnerLocation.gameObject);

      private void OnFinished() =>
         _runnerUiFactory.CreateScoreMenu();
   }
}