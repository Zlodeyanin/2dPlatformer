using UnityEngine;

public class Money : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerMovement player))
        {
            Destroy(gameObject);
        }
    }
}