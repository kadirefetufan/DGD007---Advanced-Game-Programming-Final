using Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller.LevelControllers
{
    public class LevelFailedCommand : Command
    {
        [Inject] public LevelSignals LevelSignals { get; set; }
        [Inject] public GameSignals GameSignals { get; set; }

        public override void Execute()
        {
            LevelSignals.onDestroyLevel?.Dispatch();
            GameSignals.onReset?.Dispatch();
            LevelSignals.onInitializeLevel?.Dispatch();
        }
    }
}