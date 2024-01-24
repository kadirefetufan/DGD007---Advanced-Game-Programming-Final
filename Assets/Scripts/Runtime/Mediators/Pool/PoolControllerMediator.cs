using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Model.Level;
using Runtime.Signals;
using Runtime.Views.Pool;


namespace Runtime.Mediators.Pool
{
    public class PoolControllerMediator : MediatorLite
    {
        [Inject] public PoolControllerView View { get; set; }
        [Inject] PlayerSignals PlayerSignals { get; set; }
        [Inject] ILevelModel LevelModel { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            PlayerSignals.onGetPoolResult += View.OnGetPoolResult;
            PlayerSignals.onStageAreaSuccessful.AddListener(View.OnActivateTweens);
            PlayerSignals.onStageAreaSuccessful.AddListener(View.OnChangePoolColor);
        }

        public override void OnRemove()
        {
            base.OnRemove();

            PlayerSignals.onGetPoolResult -= View.OnGetPoolResult;
            PlayerSignals.onStageAreaSuccessful.RemoveListener(View.OnActivateTweens);
            PlayerSignals.onStageAreaSuccessful.RemoveListener(View.OnChangePoolColor);
        }

        public override void OnEnabled()
        {
            base.OnEnabled();
            View.SetPoolData(LevelModel.LevelData.Data[LevelModel.GetActiveLevel()].PoolData[View.StageValue]);
        }
    }
}