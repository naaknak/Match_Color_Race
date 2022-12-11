using _Scripts;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    private int _level;
    public Text levelText;

    private void Update()
    {
        _level = PlayerLevel.Level;
        levelText.text = "LEVEL: " + _level;
    }
}
