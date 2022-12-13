using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class LevelSlider : MonoBehaviour
    {
        private Slider _slider;
        private float _targetProgress;
        private const float TargetProgressChangeAmount = 0.2f;
        private const float FillSpeed = 0.25f;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void FixedUpdate()
        {
            SliderProgressing();
        }

        private void SliderProgressing()
        {
            if (!PlayerLevel.IsOnRed) return;

            StartCoroutine(IncreaseTargetProgress());

            if (_slider.value < _targetProgress)
            {
                _slider.value += FillSpeed * Time.deltaTime;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (_slider.value == 1)
            {
                PlayerLevel.Level += 1;
                _slider.value = 0;
            }
        }

        private IEnumerator IncreaseTargetProgress()
        {
            yield return new WaitForSeconds(TargetProgressChangeAmount);
            _targetProgress += 0.1f;

        }
    }
}
