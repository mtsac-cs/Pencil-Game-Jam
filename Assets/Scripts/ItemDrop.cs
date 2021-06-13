using UnityEngine;

public class ItemDrop : MonoBehaviour, IInteractable
{
    public virtual bool CanInteract()
    {
        return Player.instance.InteractKeyDown == true;
    }

    public virtual void Interact(GameObject owner, GameObject interactable)
    {
        
    }
}
