using CodeBase.Clicker.Data;

namespace CodeBase.Infrastructure.Services
{
   public interface ISaveLoadService
   {
      ClickerProgress LoadProgress();
      void SaveProgress();
   }
}