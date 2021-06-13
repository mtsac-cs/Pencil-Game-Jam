using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class ItemDropObserver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) => OnTrigger(collision);

    private void OnTriggerStay2D(Collider2D collision) => OnTrigger(collision);

    private void OnTriggerExit2D(Collider2D collision) => OnTrigger(collision);

    private void OnTrigger(Collider2D collision)
    {
        if (collision.gameObject.HasComponent<ItemDrop>(out var itemDrop))
        {
            if (itemDrop.CanInteract())
                itemDrop.Interact(gameObject, collision.gameObject);
        }
    }
}
