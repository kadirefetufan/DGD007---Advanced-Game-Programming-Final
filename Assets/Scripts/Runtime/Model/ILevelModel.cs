using Runtime.Data.UnityObject;
using UnityEngine;

namespace Runtime.Model
{
    public interface ILevelModel
    {
        public CD_Level LevelData { get; set; }
        public byte LevelID { get; set; }
        public GameObject LevelHolder { get; set; }
        byte GetActiveLevel();
    }
}