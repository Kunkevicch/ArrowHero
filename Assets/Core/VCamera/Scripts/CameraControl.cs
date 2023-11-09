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
        private Level _level;

        [Inject]
        private void Construct(CameraTarget cameraTarget, Level level)
        {
            _cameraTarget = cameraTarget;
            _level = level;
        }

        private void Awake()
        {
            _vCam = GetComponent<CinemachineVirtualCamera>();
            AttachCameraToPlayer();
        }

        private void Update()
        {
            //float fieldWidth = _level.GroundMesh.bounds.size.x;
            //float fieldHeight = _level.GroundMesh.bounds.size.y;
            //float fieldAspect = fieldWidth / fieldHeight;
            //float desiredFieldOfView = 
            //_vCam.m_Lens.FieldOfView = desiredFieldOfView;
        }

        private void AttachCameraToPlayer() 
        {
            _vCam.Follow = _cameraTarget.transform;
        }


    }
}
