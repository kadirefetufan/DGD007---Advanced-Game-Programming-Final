using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Model.Player;
using Runtime.Signals;
using Runtime.Views.Player;
using UnityEngine;

namespace Runtime.Mediators.Player
{
    public class PlayerMediator : MediatorLite
    {
        [Inject] public PlayerView View { get; set; }
        [Inject] public IPlayerModel Model { get; set; }
        [Inject] public InputSignals InputSignals { get; set; }
        [Inject] public PlayerSignals PlayerSignals { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            InputSignals.onInputDragged.AddListener(View.OnInputDragged);
            InputSignals.onInputReleased.AddListener(View.OnInputReleased);
            InputSignals.onInputTaken.AddListener(View.OnInputTaken);

            View.onReset += OnReset;
            View.onDisableInput += OnDisableInput;
            View.onForceCommand += OnForceCommand;
        }

        private void OnDisableInput()
        {
            InputSignals.onDisableInput.Dispatch();
        }

        private void OnForceCommand(Transform transformParams)
        {
            PlayerSignals.onForceCommand.Dispatch(transformParams);
        }

        private void OnReset()
        {
            Model.StageValue = 0;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            InputSignals.onInputDragged.RemoveListener(View.OnInputDragged);
            InputSignals.onInputReleased.RemoveListener(View.OnInputReleased);
            InputSignals.onInputTaken.RemoveListener(View.OnInputTaken);

            View.onReset -= OnReset;
            View.onDisableInput -= OnDisableInput;
            View.onForceCommand -= OnForceCommand;
        }

        public override void OnEnabled()
        {
            base.OnEnabled();
            View.SetPlayerData(Model.PlayerData.PlayerData);
        }
    }
}