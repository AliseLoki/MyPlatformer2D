using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    const string Horizontal = nameof(Horizontal);

    public float HorizontalInput { get; private set; }
    public bool JumpKey { get; private set; }

    public bool AttackKey { get; private set; }

    public bool StopAttackKey { get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis(Horizontal);
        JumpKey = Input.GetKeyDown(KeyCode.Space);
        AttackKey = Input.GetKeyDown(KeyCode.E);
        StopAttackKey = Input.GetKeyUp(KeyCode.E);
    }
}
