using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private int _healingPower;

    public int HealingPower => _healingPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
        }
    }
}
