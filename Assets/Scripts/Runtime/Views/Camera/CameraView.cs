using Cinemachine;
using Rich.Base.Runtime.Abstract.View;
using Runtime.Views.Player;
using UnityEngine;

namespace Runtime.Views.Camera
{
    public class CameraView : RichView
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        #endregion

        #endregion

        public void AssignCameraTarget()
        {
            var player = FindObjectOfType<PlayerView>();
            virtualCamera.Follow = player.transform;
        }
    }
}