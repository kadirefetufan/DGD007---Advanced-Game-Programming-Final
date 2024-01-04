using Runtime.Model;
using strange.extensions.command.impl;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Runtime.Controller
{
    public class InitializeLevelCommand : Command
    {
        [Inject] private ILevelModel LevelModel { get; set; }

        private byte _currentLevelID;

        public override void Execute()
        {
            _currentLevelID = GetActiveLevel();
            InitializeLevel();
        }

        private byte GetActiveLevel()
        {
            return LevelModel.GetActiveLevel();
        }

        private void InitializeLevel()
        {
            Object.Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefabs/level {LevelModel.LevelID}"), LevelModel.LevelHolder.transform,
                true);
        }
    }
}