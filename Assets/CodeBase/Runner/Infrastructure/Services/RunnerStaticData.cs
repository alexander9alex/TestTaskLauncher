using CodeBase.Runner.StaticData;
using UnityEngine;

namespace CodeBase.Runner.Infrastructure.Services
{
   class RunnerStaticData : IRunnerStaticData
   {
      private const string LocationDataPath = "StaticData/Runner/LocationData";

      public LocationData GetLocationData() =>
         Resources.Load<LocationData>(LocationDataPath);
   }
}