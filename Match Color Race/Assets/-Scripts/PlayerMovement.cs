using System;
using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _rb;
        private Transform _transform;

        public float speedingUpDuration = 0.2f;
        public LayerMask ground;
        public float movespeedZ = 4.5f;
        public float movespeedX = 3f;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector3(horizontal * movespeedX, 0, movespeedZ);
            
            
            if (Physics.Raycast(_transform.position, transform.TransformDirection(Vector3.down), out var hit,ground))
            {
                if (hit.transform.CompareTag("Red"))
                {
                    StartCoroutine(HitRed());
                }

                else
                {
                    StartCoroutine(HitOther());
                }
            }
        }

        private IEnumerator HitOther()
        {
            yield return new WaitForSeconds(speedingUpDuration);
            if (movespeedZ >= 3f)
            {
                movespeedZ -= 0.1f;
            }
        }
        
        private IEnumerator HitRed()
        {
            yield return new WaitForSeconds(speedingUpDuration);
            if (movespeedZ <= 10f)
            {
                movespeedZ += 0.1f;
            }
            
        }

        
    }
}
