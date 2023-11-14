using Cinemachine;
using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class CameraControl : MonoBehaviour
    {

        [SerializeField]
        [Range(0,1f)]
        private float WidthOrHeight;

        [SerializeField]
        private Vector2 _defaultResolution;

        private CinemachineVirtualCamera _vCam;
        
        private CameraTarget _cameraTarget;

        [Inject]
        private void Construct(CameraTarget cameraTarget)
        {
            _cameraTarget = cameraTarget;
        }

        private void Awake()
        {
            _vCam = GetComponent<CinemachineVirtualCamera>();
            AttachCameraToPlayer();
        }

        private void AttachCameraToPlayer() 
        {
            _vCam.Follow = _cameraTarget.transform;
        }


    }
}
