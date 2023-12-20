using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _sip = 5;

    private int _index = 1;
    private Coroutine _coroutine;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth);
    }

    public void ChangeHealth(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth == 0)
        {
            Die();
        }
    }

    public void GetBlood()
    {
        _coroutine = StartCoroutine(Countdown(_index));
    }

    public void GiveBlood()
    {
        _coroutine = StartCoroutine(Countdown(-_index));
    }

    private IEnumerator Countdown(int index, int vampirismDuration = 6)
    {
        for (int i = vampirismDuration; i > 0; i--)
        {
            ChangeHealth(_sip * index);
            yield return new WaitForSeconds(1f);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
