using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsJumping = nameof(IsJumping);
    private const string PlayerAttack = nameof(PlayerAttack);

    private bool _isGrounded = false;
    private bool _isWalking = false;

    private Animator _animator;
    private PlayerInput _playerInput;
    private GroundChecker _groundChecker;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void Update()
    {
        SetJumpAnimation();
        SetWalkAnimation();
        SetAttackAnimation();
    }

    private void SetWalkAnimation()
    {
        if (_playerInput.HorizontalInput == 0 && _isWalking == true)
        {
            _isWalking = false;
            _animator.SetBool(IsWalking, false);
        }

        if (_playerInput.HorizontalInput != 0 && _isWalking == false)
        {
            _isWalking = true;
            _animator.SetBool(IsWalking, true);
        }
    }

    private void SetJumpAnimation()
    {
        if (_groundChecker.IsGrounded == false && _isGrounded == false)
        {
            _isGrounded = true;
            _animator.SetBool(IsJumping, true);
        }
        if (_groundChecker.IsGrounded == true && _isGrounded == true)
        {
            _isGrounded = false;
            _animator.SetBool(IsJumping, false);
        }
    }

    private void SetAttackAnimation()
    {
        if (_playerInput.AttackKey == true)
        {
            _animator.Play(PlayerAttack);
        }  
    }
}
