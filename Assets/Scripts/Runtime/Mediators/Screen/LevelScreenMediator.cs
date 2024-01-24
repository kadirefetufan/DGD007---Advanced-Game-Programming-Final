using Runtime.Signals;
using Runtime.Views.Screen;
using strange.extensions.mediation.impl;

namespace Runtime.Mediators.Screen
{
    public class LevelScreenMediator : Mediator
    {
        [Inject] public UISignals UISignals { get; set; }
        [Inject] public LevelScreenView View { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            UISignals.onSetStageColor.AddListener(View.OnSetStageColor);
            UISignals.onSetNewLevelValue.AddListener(View.OnSetLevelValue);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            UISignals.onSetStageColor.RemoveListener(View.OnSetStageColor);
            UISignals.onSetNewLevelValue.RemoveListener(View.OnSetLevelValue);
        }
    }
}