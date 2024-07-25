using System.Threading.Tasks;

namespace CodeBase.Clicker.Infrastructure
{
   public interface IClickerUiFactory
   {
      Task CreateClickerMenu();
   }
}