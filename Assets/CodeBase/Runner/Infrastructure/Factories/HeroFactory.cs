using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using CodeBase.Runner.Data;
using CodeBase.Runner.Game.Hero;
using CodeBase.Runner.Infrastructure.Services;
using CodeBase.Runner.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Runner.Infrastructure.Factories
{
   class HeroFactory : IHeroFactory
   {
      private readonly LocationData _locationData;
      private readonly IInputService _inputService;
      private readonly IRunnerAssets _assets;

      private GameObject _hero;

      public HeroFactory(IRunnerStaticData staticData, IInputService inputService, IRunnerAssets assets)
      {
         _inputService = inputService;
         _assets = assets;
         _locationData = staticData.GetLocationData();
      }

      public async Task CreateHero()
      {
         GameObject heroPrefab = await _assets.Load<GameObject>(RunnerAssetAddress.Hero);
         _hero = Object.Instantiate(heroPrefab, _locationData.HeroPosition, Quaternion.identity);
         _hero.GetComponent<HeroMover>().Construct(_inputService);
         _hero.GetComponent<HeroAnimator>().Construct(_inputService);
      }

      public void CleanUp()
      {
         Object.Destroy(_hero);
      }
   }
}