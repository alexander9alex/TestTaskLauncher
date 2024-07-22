using CodeBase.Clicker.Data;

namespace CodeBase.Clicker.Infrastructure.Services
{
   public interface ILoader
   {
      public void LoadProgress(ClickerProgress progress);
      
   }
}