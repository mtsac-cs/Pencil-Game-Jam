using System;
using UnityEngine;

public class PencilModel : MonoBehaviour
{
    public PencilState CurrentState { get; private set; }
    public PencilState[] bodyTypes;
    public PencilState bodyInfo;

    Animator animator; 

    void Start()
    {
        if (bodyInfo == null)
        {
            throw new Exception(nameof(bodyInfo) + " in player is null please drag in a base body type from Scriptable Objects");
        }

        animator = GetComponent<Animator>();
        gameObject.AddComponent<ItemDropObserver>();
        gameObject.AddComponent<PencilLeadStat>();
        gameObject.AddComponent<PencilEraserStat>();
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
