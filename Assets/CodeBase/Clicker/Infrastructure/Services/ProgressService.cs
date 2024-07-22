using CodeBase.Clicker.Data;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Clicker.Infrastructure.Services
{
   class ProgressService : IProgressService
   {
      public ClickerProgress Progress { get; set; }
   }
}