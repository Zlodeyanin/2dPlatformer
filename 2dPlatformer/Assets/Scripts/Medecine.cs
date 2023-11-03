using UnityEngine;

public class Medecine : MonoBehaviour
{
    [SerializeField] private int _healQuantity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerHealth player))
        {
            player.Heal(_healQuantity);
            Destroy(gameObject);
        }
    }
}