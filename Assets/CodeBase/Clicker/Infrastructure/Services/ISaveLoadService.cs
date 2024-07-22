using CodeBase.Clicker.Data;

namespace CodeBase.Clicker.Infrastructure.Services
{
   public interface ISaveLoadService
   {
      ClickerProgress LoadProgress();
      void SaveProgress();
   }
}