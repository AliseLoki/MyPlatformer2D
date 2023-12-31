using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HitPoints))]
public class Player : MonoBehaviour
{
    [SerializeField] private HitPoints _health;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private int _damage = 30;

    private int _gold;

    public int Damage => _damage;

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
                enemy.GetComponent<HitPoints>().ChangeHealth(-_damage);
            }
        }
    }
}
