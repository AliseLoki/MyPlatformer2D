using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private int _damage = 30;

    private int _gold;

    public event UnityAction<int> GoldChanged;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            _gold++;
            GoldChanged?.Invoke(_gold);
        }

        if (collider.TryGetComponent(out Healing healing))
        {
            if (_health.CurrentHealth < _health.MaxHealth)
            {
                _health.ChangeHealth(healing.HealingPower);
                Destroy(healing.gameObject);
            }
        }

        if (collider.TryGetComponent(out Enemy enemy))
        {
            if (_playerMover.IsAttacking == true)
            {
                enemy.GetComponent<Health>().ChangeHealth(-_damage);
            }
        }
    }
}
