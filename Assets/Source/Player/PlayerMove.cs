using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpHeight;

    private void OnEnable()
    {
        _input.JumpButtonPressed += OnJumpButtonPressed;
    }

    private void OnDisable()
    {
        _input.JumpButtonPressed -= OnJumpButtonPressed;
    }

    private void OnJumpButtonPressed()
    {
        Jump();
    }

    private void Jump()
    {
        float jumpForce = Mathf.Sqrt(2f * (-Physics2D.gravity.y) * _rigidbody2D.gravityScale * _jumpHeight);
        _rigidbody2D.velocity = Vector2.up * jumpForce;
    }
}
