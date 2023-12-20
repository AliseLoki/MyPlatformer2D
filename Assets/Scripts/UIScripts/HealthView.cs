using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private float _duration = 2;
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _health.HealthChanged += Change;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= Change;
    }

    private void Change(int health)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangehealthBar(health));
    }

    private IEnumerator ChangehealthBar(int health)
    {
        while (enabled)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _duration);
            yield return null;
        }
    }
}
