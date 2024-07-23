using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Runner.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Runner/Location Data", fileName = "LocationData", order = 0)]
   internal class LocationData : ScriptableObject
   {
      [FormerlySerializedAs("Location")]
      public GameObject RunnerLocation;
      public GameObject Finish;
      public Vector3 FinishPosition;
      public Vector3 HeroPosition;
   }
}