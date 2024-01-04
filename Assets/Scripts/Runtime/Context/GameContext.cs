using Rich.Base.Runtime.Concrete.Context;
using Rich.Base.Runtime.Extensions;
using Runtime.Controller;
using Runtime.Model;
using Runtime.Signals;

namespace Runtime.Context
{
    public class GameContext : RichMVCContext
    {
        private GameSignals _gameSignals;
        private CameraSignals _cameraSignals;
        private PlayerSignals _playerSignals;
        private InputSignals _inputSignals;
        private LevelSignals _levelSignals;

        protected override void mapBindings()
        {
            base.mapBindings();

            //Injection Bindings
            _gameSignals = injectionBinder.BindCrossContextSingletonSafely<GameSignals>();
            _cameraSignals = injectionBinder.BindCrossContextSingletonSafely<CameraSignals>();
            _playerSignals = injectionBinder.BindCrossContextSingletonSafely<PlayerSignals>();
            _inputSignals = injectionBinder.BindCrossContextSingletonSafely<InputSignals>();
            _levelSignals = injectionBinder.BindCrossContextSingletonSafely<LevelSignals>();

            injectionBinder.Bind<ILevelModel>().To<LevelModel>().CrossContext().ToSingleton();

            //Mediation Bindings

            //Command Bindings
            commandBinder.Bind(_levelSignals.onInitializeLevel).To<InitializeLevelCommand>();
            commandBinder.Bind(_levelSignals.onDestroyLevel).To<DestroyLevelCommand>();
        }

        public override void Launch()
        {
            base.Launch();
            _levelSignals.onInitializeLevel.Dispatch();
        }
    }
}