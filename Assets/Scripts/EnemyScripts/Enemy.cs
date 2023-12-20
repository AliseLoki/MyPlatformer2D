using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Health))]

public class Enemy : MonoBehaviour
{
    private const string IsAttacking = nameof(IsAttacking);

    [SerializeField] private int _damage = 20;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _animator.SetBool(IsAttacking, true);
            player.GetComponent<Health>().ChangeHealth(-_damage);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool(IsAttacking, false);
    }
}
