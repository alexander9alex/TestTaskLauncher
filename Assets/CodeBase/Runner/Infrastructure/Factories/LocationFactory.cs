using CodeBase.Runner.Infrastructure.Services;
using CodeBase.Runner.StaticData;
using UnityEngine;

namespace CodeBase.Runner.Infrastructure.Factories
{
   class LocationFactory : ILocationFactory
   {
      private readonly LocationData _locationData;

      public LocationFactory(IRunnerStaticData staticData) =>
         _locationData = staticData.GetLocationData();

      public void CreateRunnerLocation()
      {
         Transform runnerLocation = Object.Instantiate(_locationData.RunnerLocation).transform;
         Object.Instantiate(_locationData.Finish, _locationData.FinishPosition, Quaternion.identity, runnerLocation);
      }
   }
}