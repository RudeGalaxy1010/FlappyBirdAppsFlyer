using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    private float _speed;

    public void Construct(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
