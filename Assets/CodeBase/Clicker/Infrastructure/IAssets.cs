using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Clicker.Infrastructure
{
   public interface IAssets
   {
      Task<T> Load<T>(AssetReference assetReference) where T : class;
      Task<T> Load<T>(string address) where T : class;
      void CleanUp();
   }
}