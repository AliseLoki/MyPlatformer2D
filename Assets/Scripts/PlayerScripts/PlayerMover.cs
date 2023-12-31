using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent (typeof(HitPoints))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _abilityDistance = 10f;
    [SerializeField] private LayerMask _layerMask;

    private float _rotationAngle = 0;
    private bool _isAttacking;
    
    private Rigidbody2D _rigidbody2D;
    private PlayerInput _playerInput;
    private GroundChecker _groundChecker;

    public bool IsAttacking => _isAttacking;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void Update()
    {
        ControlJump();
        MoveLeftOrRight();
        Attack();
        DrinkBlood();
    }

    private void MoveLeftOrRight()
    {
        if (_playerInput.HorizontalInput == 0)
            return;
        else
        {
            Move();
            Rotate();
            Attack();
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        if (_playerInput.HorizontalInput > 0)
            _rotationAngle = 0;
        else
            _rotationAngle = 180;

        transform.rotation = Quaternion.Euler(0, _rotationAngle, 0);
    }

    private void ControlJump()
    {
        if (_playerInput.JumpKey && _groundChecker.IsGrounded == true)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce , ForceMode2D.Impulse);
    }

    private void Attack()
    {
        if(_playerInput.AttackKey)
        {
            _isAttacking = true;
        }
        else if(_playerInput.StopAttackKey)
        {
            _isAttacking = false;
        }
    }

    private void DrinkBlood()
    {
        if(_playerInput.VampireAbilityKey)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _abilityDistance, _layerMask);

            if (hit)
            {
                GetComponent<HitPoints>().GetBlood();
                hit.collider.GetComponent<HitPoints>().GiveBlood();
            }
        }
    }
}
