using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    private const string IsAttacking = nameof(IsAttacking);
    [SerializeField] private int _damage;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ChangeHealth(-_damage);
            _animator.SetBool(IsAttacking, true);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool(IsAttacking, false);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
