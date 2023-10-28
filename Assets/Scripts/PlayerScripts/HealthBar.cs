using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _player.HealthChanged += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeHealthBar;
    }

    private void ChangeHealthBar(int health)
    {
        _slider.value = health;
    }
}
