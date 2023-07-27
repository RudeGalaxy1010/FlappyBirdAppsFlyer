using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PipeWall : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Pipe _upperPipe;
    [SerializeField] private Pipe _bottomPipe;
    [SerializeField] private int _pointToAdd;

    public void Construct(float upperPipeY, float bottomPipeY)
    {
        _upperPipe.transform.position = new Vector2(_upperPipe.transform.position.x, upperPipeY);
        _bottomPipe.transform.position = new Vector2(_bottomPipe.transform.position.x, bottomPipeY);
        float UpperColliderBoundPosition = _upperPipe.transform.position.y - _upperPipe.transform.localScale.y / 2f;
        float BottomColliderBoundPosition = _bottomPipe.transform.position.y + _bottomPipe.transform.localScale.y / 2f;
        float colliderSizeY = UpperColliderBoundPosition - BottomColliderBoundPosition;
        _collider.size = new Vector2(_collider.size.x, colliderSizeY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Score score))
        {
            score.AddPoints(_pointToAdd);
        }
    }
}
