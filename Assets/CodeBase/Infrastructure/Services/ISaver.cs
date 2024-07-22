using CodeBase.Clicker.Data;

namespace CodeBase.Infrastructure.Services
{
   public interface ISaver
   {
      public void SaveProgress(ClickerProgress progress);
   }
}