using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private PlayerMover _playerMover;

    private int _maxHealth = 100;
    private int _gold;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> GoldChanged;


    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void ChangeHealth(int value)
    {
        _health = Mathf.Clamp(_health + value, 0, _maxHealth);
        HealthChanged?.Invoke(_health);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            _gold++;
            GoldChanged?.Invoke(_gold);
        }

        if (collider.TryGetComponent(out Healing healing))
        {
            ChangeHealth(healing.HealingPower);
        }

        if (collider.TryGetComponent(out Enemy enemy))
        {
            if(_playerMover.IsAttacking == true)
            {
                enemy.Die();
            }
        }
    }
}
