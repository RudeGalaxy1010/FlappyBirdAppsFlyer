using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : Pauseable
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpHeight;

    private float _gravityScale;
    private bool _isActive = true;

    private void OnEnable()
    {
        _input.JumpButtonPressed += OnJumpButtonPressed;
    }

    private void OnDisable()
    {
        _input.JumpButtonPressed -= OnJumpButtonPressed;
    }

    private void Start()
    {
        _gravityScale = _rigidbody2D.gravityScale;
    }

    private void OnJumpButtonPressed()
    {
        Jump();
    }

    private void Jump()
    {
        if (_isActive == false)
        {
            return;
        }

        float jumpForce = Mathf.Sqrt(2f * (-Physics2D.gravity.y) * _rigidbody2D.gravityScale * _jumpHeight);
        _rigidbody2D.velocity = Vector2.up * jumpForce;
    }

    public override void SetPause(bool isPause)
    {
        _isActive = !isPause;
        _rigidbody2D.gravityScale = _isActive ? _gravityScale : 0f;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
