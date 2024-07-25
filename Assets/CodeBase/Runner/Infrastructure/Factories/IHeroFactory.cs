using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runner.Infrastructure.Factories
{
   internal interface IHeroFactory
   {
      Task CreateHero();
      void CleanUp();
   }
}