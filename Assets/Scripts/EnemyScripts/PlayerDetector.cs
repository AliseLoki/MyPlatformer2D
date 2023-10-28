using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public event UnityAction <bool> PlayerDetected;
    public event UnityAction <Player> PlayerFound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            PlayerDetected?.Invoke(true);
            PlayerFound?.Invoke(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerDetected?.Invoke(false);
            PlayerFound?.Invoke(null);
        }
    }
}
