using System.Collections.Generic;
using CodeBase.Runner.Infrastructure.Services;

namespace CodeBase.Infrastructure.Services
{
   class ProgressChangers : IProgressChangers
   {
      public List<ISaver> Savers { get; set; } = new();
      public List<ILoader> Loaders { get; set; } = new();
      public void Register(object obj)
      {
         if (obj is ISaver saver)
            Savers.Add(saver);
         
         if (obj is ILoader loader)
            Loaders.Add(loader);
      }

      public void CleanUp()
      {
         Savers.Clear();
         Loaders.Clear();
      }
   }
}