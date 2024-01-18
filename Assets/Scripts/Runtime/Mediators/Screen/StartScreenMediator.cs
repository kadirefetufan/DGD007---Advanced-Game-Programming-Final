using Rich.Base.Runtime.Signals;
using Runtime.Signals;
using Runtime.Views.Screen;
using strange.extensions.mediation.impl;

namespace Runtime.Mediators.Screen
{
    public class StartScreenMediator : Mediator
    {
        [Inject] public StartScreenView View { get; set; }
        [Inject] public UISignals UISignals { get; set; }
        [Inject] public CameraSignals CameraSignals { get; set; }
        [Inject] public CoreScreenSignals CoreScreenSignals { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.onPlay += OnPlay;
        }

        private void OnPlay()
        {
            UISignals.onPlay.Dispatch();
            CameraSignals.onSetCameraTarget.Dispatch();
            CoreScreenSignals.ClearLayerPanel.Dispatch(0);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.onPlay -= OnPlay;
        }
    }
}