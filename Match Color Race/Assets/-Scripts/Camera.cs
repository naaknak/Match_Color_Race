using Cinemachine;
using UnityEngine;

namespace _Scripts
{
    public class Camera : MonoBehaviour
    {
        //Vector3.Lerp Kullan
        private CinemachineVirtualCamera _vcam;

        private void Awake()
        {
            _vcam = GetComponent<CinemachineVirtualCamera>();
        }

        private void Update()
        {
            if (PlayerMovement.MovespeedZ > 6)
            {
                _vcam.m_Lens.FieldOfView = 63;
            }

            else
            {
                _vcam.m_Lens.FieldOfView = 60;
            }
        }
    }
}
