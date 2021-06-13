using System;
using System.Linq;
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
        gameObject.AddComponent<InteractionObserver>();
        gameObject.AddComponent<PencilLeadStat>();
        gameObject.AddComponent<PencilEraserStat>();
    }

    public void UpdateState(int id)
    {
        if (id > bodyTypes.Length)
        {
            Debug.LogError("id is out of range (body type you are trying to access does not exist");
            return;
        }

        UpdateState(bodyTypes[id]);
    }

    public void UpdateState(PencilState state)
    {
        bodyInfo = state;
        animator.SetInteger("BodyType ID", bodyInfo.bodyTypeID);
    }

    public bool HasEraser() => bodyInfo.hasEraser;

    public bool HasLead() => bodyInfo.hasLead;

    public void UpdateModel()
    {
        bool removeLead = GetComponent<PencilLeadStat>().StatValue == 0;
        bool removeEraser = GetComponent<PencilEraserStat>().StatValue == 0;

        for (int i = 0; i < bodyTypes.Length; i++)
        {
            if (i == 0)
            {
                UpdateState(i);
                break;
            }

            var bodyType = bodyTypes[i];
            if (bodyType.hasEraser && removeEraser)
                continue;

            if (bodyType.hasLead && removeLead)
                continue;

            UpdateState(i);
        }
    }
}
