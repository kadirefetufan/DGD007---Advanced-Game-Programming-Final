using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Signals;
using Runtime.Views.Camera;

namespace Runtime.Mediators.Camera
{
    public class CameraMediator : MediatorLite
    {
        [Inject] private CameraView _cameraView { get; set; }
        [Inject] private CameraSignals _cameraSignals { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();

            _cameraSignals.onSetCameraTarget.AddListener(OnSetCameraTarget);
        }

        private void OnSetCameraTarget()
        {
            _cameraView.AssignCameraTarget();
        }

        public override void OnRemove()
        {
            base.OnRemove();

            _cameraSignals.onSetCameraTarget.RemoveListener(OnSetCameraTarget);
        }
    }
}