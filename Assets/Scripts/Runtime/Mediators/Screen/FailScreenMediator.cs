using System.Runtime.InteropServices;
using Rich.Base.Runtime.Signals;
using Runtime.Signals;
using Runtime.Views.Screen;
using strange.extensions.mediation.impl;

namespace Runtime.Mediators.Screen
{
    public class FailScreenMediator : Mediator
    {
        [Inject] public FailScreenView View { get; set; }
        [Inject] public LevelSignals LevelSignals { get; set; }
        [Inject] public CoreGameSignals CoreGameSignals { get; set; }
        [Inject] public CoreScreenSignals CoreScreenSignals { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.onRestartLevel += OnRestartLevel;
        }


        private void OnRestartLevel()
        {
            LevelSignals.onNextLevel?.Dispatch();
            CoreGameSignals.onReset?.Dispatch();
            CoreScreenSignals.ClearLayerPanel?.Dispatch(2);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.onRestartLevel -= OnRestartLevel;
        }
    }
}