using Runtime.Model;
using Runtime.Model.Level;
using Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller.LevelControllers
{
    public class LevelSuccessfulCommand : Command
    {
        [Inject] public ILevelModel LevelModel { get; set; }
        [Inject] public LevelSignals LevelSignals { get; set; }
        [Inject] public GameSignals GameSignals { get; set; }

        public override void Execute()
        {
            LevelModel.IncrementLevel();
            LevelSignals.onDestroyLevel?.Dispatch();
            GameSignals.onReset?.Dispatch();
            LevelSignals.onInitializeLevel?.Dispatch();
        }
    }
}