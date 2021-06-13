using UnityEngine;

public interface IInteractable
{
    bool CanInteract();

    void Interact(GameObject owner, GameObject interactable);
}