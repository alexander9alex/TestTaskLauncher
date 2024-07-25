using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
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
      private readonly IRunnerAssets _assets;
      
      private Transform _runnerLocation;

      public LocationFactory(IRunnerStaticData staticData, IRunnerUiFactory runnerUiFactory, IRunnerAssets assets)
      {
         _runnerUiFactory = runnerUiFactory;
         _assets = assets;
         _locationData = staticData.GetLocationData();
      }

      public async Task CreateRunnerLocation()
      {
         GameObject locationPrefab = await _assets.Load<GameObject>(_locationData.RunnerLocationReference);
         _runnerLocation = Object.Instantiate(locationPrefab).transform;

         GameObject finishPrefab = await _assets.Load<GameObject>(_locationData.FinishReference);
         GameObject finish = Object.Instantiate(finishPrefab, _locationData.FinishPosition, Quaternion.identity, _runnerLocation);
         finish.GetComponent<FinishTrigger>().Construct(OnFinished);
      }

      public void CleanUp() =>
         Object.Destroy(_runnerLocation.gameObject);

      private void OnFinished() =>
         _runnerUiFactory.CreateResultMenu();
   }
}