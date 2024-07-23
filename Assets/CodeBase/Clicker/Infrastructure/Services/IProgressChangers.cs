using System.Collections.Generic;

namespace CodeBase.Clicker.Infrastructure.Services
{
   public interface IProgressChangers
   {
      public List<ISaver> Savers { get; }
      public List<ILoader> Loaders { get; }
      void Register(object obj);
   }
}