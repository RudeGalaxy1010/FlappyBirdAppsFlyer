using UnityEngine;

public class HorizontalMove : Pauseable
{
    private float _speed;
    private bool _isActive = true;

    public void Construct(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        if (_isActive == false)
        {
            return;
        }

        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    public override void SetPause(bool isPause)
    {
        _isActive = !isPause;
    }
}
