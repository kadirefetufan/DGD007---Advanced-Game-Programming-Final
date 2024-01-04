using Runtime.Data.UnityObject;
using strange.extensions.context.api;
using UnityEngine;

namespace Runtime.Model
{
    public class LevelModel : ILevelModel
    {
        [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }

        private CD_Level _levelData { get; set; }

        public byte LevelID { get; set; }
        public GameObject LevelHolder { get; set; }

        private const string LevelDataPath = "Data/Levels";
        private const string LevelHolderName = "LevelHolder";

        [PostConstruct]
        public void OnPostConstruct()
        {
            LevelData = Resources.Load<CD_Level>(LevelDataPath);

            LevelHolder = new GameObject(LevelHolderName)
            {
                transform =
                {
                    parent = ContextView.transform
                }
            };
        }

        public CD_Level LevelData
        {
            get
            {
                if (_levelData == null)
                    OnPostConstruct();
                return _levelData;
            }
            set => _levelData = value;
        }


        public byte GetActiveLevel()
        {
            if (ES3.FileExists())
            {
                if (ES3.KeyExists("Level"))
                {
                    return ES3.Load<byte>("Level");
                }
            }

            return 0;
        }
    }
}