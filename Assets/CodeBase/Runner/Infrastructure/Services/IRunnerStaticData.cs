using CodeBase.Runner.Data;
using CodeBase.Runner.StaticData;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal interface IRunnerStaticData
   {
      LocationData GetLocationData();
      HeroData GetHeroData();
      MenuData GetMenuData();
   }
}