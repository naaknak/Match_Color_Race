using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class LevelDisplay : MonoBehaviour
    {
        private int _level;
        public Text levelText;

        private void Update()
        {
            _level = PlayerLevel.Level;
            levelText.text = _level.ToString();
        }
    }
}
