using CodeBase.Runner.Data;
using CodeBase.Runner.StaticData;
using UnityEngine;

namespace CodeBase.Runner.Infrastructure.Services
{
   class RunnerStaticData : IRunnerStaticData
   {
      private const string LocationDataPath = "StaticData/Runner/LocationData";
      private const string HeroDataPath = "StaticData/Runner/HeroData";

      public LocationData GetLocationData() =>
         Resources.Load<LocationData>(LocationDataPath);

      public HeroData GetHeroData() =>
         Resources.Load<HeroData>(HeroDataPath);
   }
}