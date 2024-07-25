using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Clicker.Infrastructure
{
   class AssetProvider : IClickerAssets, IRunnerAssets
   {
      private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new Dictionary<string, AsyncOperationHandle>();
      private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();

      public async Task<T> Load<T>(AssetReference assetReference) where T : class
      {
         if (_completedCache.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
            return completedHandle.Result as T;

         AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetReference);
         
         handle.Completed += completed => _completedCache[assetReference.AssetGUID] = completed;
         
         AddHandle(assetReference.AssetGUID, handle);

         return await handle.Task;
      }

      public async Task<T> Load<T>(string address) where T : class
      {
         if (_completedCache.TryGetValue(address, out AsyncOperationHandle completedHandle))
            return completedHandle.Result as T;

         AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(address);
         
         handle.Completed += completed => _completedCache[address] = completed;
         
         AddHandle(address, handle);

         return await handle.Task;
      }

      public void CleanUp()
      {  
         foreach (List<AsyncOperationHandle> handles in _handles.Values)
         foreach (AsyncOperationHandle handle in handles)
               Addressables.Release(handle);
         
         _completedCache.Clear();
         _handles.Clear();
      }
      
      private void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class
      {
         if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourcedHandle))
         {
            resourcedHandle = new List<AsyncOperationHandle>();
            _handles[key] = resourcedHandle;
         }

         resourcedHandle.Add(handle);
      }
   }
}