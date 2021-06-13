using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PencilDrop : ItemDrop
{
    public PencilState partInfo;


    public override void Interact(GameObject owner, GameObject interactable)
    {
        var player = owner.GetComponent<Player>();

        if (partInfo.bodyTypeID >= 0 && partInfo.bodyTypeID <= 3)
        {
            player.pencilModel.UpdatePart(partInfo.bodyTypeID);
            GameObject.Destroy(interactable);
        }
        else
        {
            Debug.Log("The ID in Player does not match any known " + nameof(PencilState) + " or vice versa");
        }
    }
}
