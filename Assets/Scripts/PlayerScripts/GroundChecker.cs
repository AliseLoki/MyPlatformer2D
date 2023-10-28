using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
            _isGrounded = false;
    }
}
