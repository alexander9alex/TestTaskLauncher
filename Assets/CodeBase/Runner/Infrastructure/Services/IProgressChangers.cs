using System.Collections.Generic;

namespace CodeBase.Runner.Infrastructure.Services
{
   internal interface IProgressChangers
   {
      public List<ISaver> Savers { get; }
      public List<ILoader> Loaders { get; }
      void Register(object obj);
      public void CleanUp();
   }
}