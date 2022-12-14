using Cinemachine;
using UnityEngine;

namespace _Scripts
{
    public class Camera : MonoBehaviour
    {
        //Vector3.Lerp Kullan
        private CinemachineVirtualCamera _vcam;
        
        public Transform playerTransform;
        public Transform cameraTransform;

        private Vector3 _startingPos;
        private Vector3 _endingPos = new Vector3(2.5f, 9f, -12f);
        private float _duration = 2f;
        private float _elapsedTime;

        private void Awake()
        {
            _vcam = GetComponent<CinemachineVirtualCamera>();
            _startingPos = cameraTransform.position;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            var percentageComplete = _elapsedTime / _duration;

            cameraTransform.position = Vector3.Lerp(_startingPos, _endingPos, percentageComplete);
        }
    }
}
