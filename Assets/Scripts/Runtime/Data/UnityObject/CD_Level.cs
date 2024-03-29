using System.Collections.Generic;
using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Level", menuName = "Picker3D/CD_Level", order = 0)]
    public class CD_Level : ScriptableObject
    {
        public List<LevelData> Data = new List<LevelData>();
    }
}