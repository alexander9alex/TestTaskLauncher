using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;

namespace CodeBase.Runner.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Runner/Location Data", fileName = "LocationData", order = 0)]
   internal class LocationData : ScriptableObject
   {
      public AssetReferenceGameObject RunnerLocationReference;
      public AssetReferenceGameObject FinishReference;
      public Vector3 FinishPosition;
      public Vector3 HeroPosition;
   }
}