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
                switch (player.GetComponent<Player>().bodyInfo.bodyTypeID)
                {
                    case 0://has nothing
                        player.bodyInfo = partInfo;
                        break;
                    case 1://already has eraser
                        player.GetComponent<Player>().updatePart(3);
                        break;
                    case 2://already has lead
                        player.GetComponent<Player>().updatePart(3);
                        break;
                    case 3://has everything
                        //so far doesnt do anything
                        break;
                    default:
                        Debug.Log("The ID in Player does not match any known PencilPartInfo or vice versa");
                        break;
                }
                player.bodyInfo = partInfo;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
