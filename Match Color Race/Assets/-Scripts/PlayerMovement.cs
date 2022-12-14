using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public static float MovespeedZ = 4.1f;
        
        private Rigidbody _rb;
        private Transform _transform;
        private float _maxSpeedZ;
        private float _defaultSpeed;
        private float _maxSpeedPerLevel;
        private int _level;

        public float speedChangeAmount = 0.4f;
        public LayerMask ground;
        public float movespeedX = 3f;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            _maxSpeedZ = _defaultSpeed;
            _maxSpeedPerLevel = 10f;
            _defaultSpeed = 4.1f;
            _level = PlayerLevel.Level;
        }

        private void FixedUpdate()
        {
            Move();
            IncreaseMaxSpeed();
        }

        private void Move()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector3(horizontal * movespeedX, 0, MovespeedZ);
            
            
            if (Physics.Raycast(_transform.position, transform.TransformDirection(Vector3.down), out var hit,ground))
            {
                if (hit.transform.CompareTag("Red"))
                {
                    _maxSpeedZ = _maxSpeedPerLevel;
                    StartCoroutine(HitRed());
                }

                else
                {
                    _maxSpeedZ = _defaultSpeed;
                    StartCoroutine(HitOther());
                }
            }
        }
        
        private IEnumerator HitRed()
        {
            yield return new WaitForSeconds(speedChangeAmount);
            if (MovespeedZ <= _maxSpeedZ)
            {
                MovespeedZ += 0.1f;
            }
            
        }
        private IEnumerator HitOther()
        {
            yield return new WaitForSeconds(speedChangeAmount);
            if (MovespeedZ > _maxSpeedZ)
            {
                MovespeedZ -= 0.1f;
            }
        }

        private void IncreaseMaxSpeed()
        {
            if (_level == PlayerLevel.Level) return;
            _level += 1;
            _maxSpeedPerLevel += 5f;
        }
        
    }
}
