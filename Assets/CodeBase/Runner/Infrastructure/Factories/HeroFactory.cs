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
      private readonly HeroData _heroData;
      private readonly LocationData _locationData;
      private readonly IInputService _inputService;

      public HeroFactory(IRunnerStaticData staticData, IInputService inputService)
      {
         _inputService = inputService;
         _locationData = staticData.GetLocationData();
         _heroData = staticData.GetHeroData();
      }

      public void CreateHero()
      {
         GameObject hero = Object.Instantiate(_heroData.Hero, _locationData.HeroPosition, Quaternion.identity);
         hero.GetComponent<HeroMover>().Construct(_inputService);
         hero.GetComponent<HeroAnimator>().Construct(_inputService);
      }
   }
}