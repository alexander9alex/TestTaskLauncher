using System.Collections.Generic;
using CodeBase.Clicker.UI;

namespace CodeBase.Infrastructure.Services
{
   public interface IProgressChangers
   {
      public List<ISaver> Savers { get; }
      public List<ILoader> Loaders { get; }
      void Register(object obj);
      public void CleanUp();
   }
}