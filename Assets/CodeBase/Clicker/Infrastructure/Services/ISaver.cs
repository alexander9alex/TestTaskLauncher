using CodeBase.Clicker.Data;

namespace CodeBase.Clicker.Infrastructure.Services
{
   public interface ISaver
   {
      public void SaveProgress(ClickerProgress progress);
   }
}