using CodeBase.Clicker.Data;

namespace CodeBase.Clicker.Infrastructure.Services
{
   public interface IProgressService
   {
      ClickerProgress Progress { get; set; }
   }
}