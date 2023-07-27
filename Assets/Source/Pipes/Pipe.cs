using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.Die();
        }
    }
}
