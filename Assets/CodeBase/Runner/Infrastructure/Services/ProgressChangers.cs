using System.Collections.Generic;

namespace CodeBase.Runner.Infrastructure.Services
{
   class ProgressChangers : IProgressChangers
   {
      public List<ISaver> Savers { get; } = new();
      public List<ILoader> Loaders { get; } = new();
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