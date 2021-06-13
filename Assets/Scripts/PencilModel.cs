using UnityEngine;

public class PencilModel : MonoBehaviour
{
    public PencilState CurrentState { get; private set; }
    public PencilState bodyInfo;
    public PencilState[] bodyTypes;

    Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
        gameObject.AddComponent<ItemDropObserver>();

        if (bodyInfo == null)
        {
            Debug.LogError("BodyInfo in player is null please drag in a base body type from Scriptable Objects");
        }
    }

    public void UpdatePart(int id)
    {
        if (id > bodyTypes.Length)
        {
            Debug.LogError("id is out of range (body type you are trying to access does not exist");
            return;
        }

        bodyInfo = bodyTypes[id];
        animator.SetInteger("BodyType ID", bodyInfo.bodyTypeID);
    }
}
