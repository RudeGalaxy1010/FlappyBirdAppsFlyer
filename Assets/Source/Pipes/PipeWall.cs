using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PipeWall : MonoBehaviour
{
    private const float MinOffsetY = -2.5f;
    private const float MaxOffsetY = 2.5f;

    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private HorizontalMove _horizontalMove;
    [SerializeField] private Pipe _upperPipe;
    [SerializeField] private Pipe _bottomPipe;
    [SerializeField] private int _pointToAdd;

    public void Construct(float windowSize, float speed)
    {
        _collider.size = new Vector2(_collider.size.x, windowSize);

        SetPipesPosition(windowSize);
        SetPositonOffset();

        _horizontalMove.Construct(speed);
    }

    private void SetPositonOffset()
    {
        float offsetY = Random.Range(MinOffsetY, MaxOffsetY);
        transform.position = new Vector2(transform.position.x, offsetY);
    }

    private void SetPipesPosition(float windowSize)
    {
        float upperPipePositionY = (_upperPipe.transform.localScale.y + windowSize) / 2f;
        float bottomPipePositionY = -(_bottomPipe.transform.localScale.y + windowSize) / 2f;
        _upperPipe.transform.position = new Vector2(_upperPipe.transform.position.x, upperPipePositionY);
        _bottomPipe.transform.position = new Vector2(_bottomPipe.transform.position.x, bottomPipePositionY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Score score))
        {
            score.AddPoints(_pointToAdd);
        }
    }
}
