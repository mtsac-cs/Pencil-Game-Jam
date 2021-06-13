using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PencilPart : MonoBehaviour
{
    public PencilPartInfo partInfo;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) => OnTrigger(collision);

    private void OnTriggerStay2D(Collider2D collision) => OnTrigger(collision);

    private void OnTriggerExit2D(Collider2D collision) => OnTrigger(collision);

    private void OnTrigger(Collider2D collision)
    {
        if (collision.tag == Player.playerTag)
        {
            var player = collision.gameObject.GetComponent<Player>();
            if (player.InteractKeyDown)
            {
                player.bodyInfo = partInfo;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
