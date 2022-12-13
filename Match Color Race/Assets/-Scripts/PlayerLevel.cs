using UnityEngine;

namespace _Scripts
{
    public class PlayerLevel : MonoBehaviour
    {
        public static int Level = 1;
        public static bool IsOnRed;
        
        public LayerMask ground;

        private float _levelBar;
        private Transform _transform;

        private void Start()
        {
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            LevelingUp();
        }

        private void LevelingUp()
        {
            if (Physics.Raycast(_transform.position, transform.TransformDirection(Vector3.down), out var hit,ground))
            {
                IsOnRed = hit.transform.CompareTag("Red");
            }
        }
    }
}
