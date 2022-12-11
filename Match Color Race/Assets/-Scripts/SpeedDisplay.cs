using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class SpeedDisplay : MonoBehaviour
    {
        private int _speed;
        public Text speedText;

        private void Update()
        {
            _speed = (int)PlayerMovement.MovespeedZ;
            speedText.text = "SPEED: " + _speed;
        }
    }
}
