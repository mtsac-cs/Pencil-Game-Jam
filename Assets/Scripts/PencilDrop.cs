using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PencilDrop : ItemDrop
{
    public GameObject pickUpSound;
    public PencilState partInfo;
    public bool isLead = false;
    public override void Interact(GameObject owner, GameObject interactable)
    {
        var player = owner.GetComponent<Player>();
        if(isLead)
        {
            player.GetComponent<PencilLeadStat>().SetValue(Mathf.Clamp(player.GetComponent<PencilLeadStat>().StatValue+1,0,100));
        }
        else
        {
            player.GetComponent<PencilEraserStat>().SetValue(Mathf.Clamp(player.GetComponent<PencilEraserStat>().StatValue+1,0,100));
        }

        player.pencilModel.UpdateModel();
        pickUpSound.GetComponent<AudioSource>().Play();
        GameObject.Destroy(interactable);
    }
}
