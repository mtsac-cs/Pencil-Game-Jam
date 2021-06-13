using System;
using System.Linq;
using UnityEngine;

public class PencilModel : MonoBehaviour
{
    public PencilState CurrentState { get; private set; }
    public PencilState[] pencilStates;
    public PencilState state;

    Animator animator;
    PencilEraserStat pencilEraser;
    PencilLeadStat pencilLead;

    void Start()
    {
        if (state == null)
        {
            throw new Exception(nameof(state) + " in player is null please drag in a base body type from Scriptable Objects");
        }

        animator = GetComponent<Animator>();
        gameObject.AddComponent<InteractionObserver>();
        pencilLead = gameObject.AddComponent<PencilLeadStat>();
        pencilEraser = gameObject.AddComponent<PencilEraserStat>();
    }

    private void UpdateState(int id)
    {
        if (id > pencilStates.Length)
        {
            Debug.LogError("id is out of range (body type you are trying to access does not exist");
            return;
        }

        UpdateState(pencilStates[id]);
    }

    private void UpdateState(PencilState state)
    {
        this.state = state;
        animator.SetInteger("BodyType ID", this.state.bodyTypeID);
    }

    public bool HasEraser() => state.hasEraser;

    public bool HasLead() => state.hasLead;


    public void UpdateModel()
    {
        for (int i = 0; i < pencilStates.Length; i++)
        {
            var bodyType = pencilStates[i];

            bool hasLead = pencilLead.StatValue > 0;
            bool hasEraser = pencilEraser.StatValue > 0;

            if (hasLead && !bodyType.hasLead)
                continue;

            if (hasEraser && !bodyType.hasEraser)
                continue;


            if (!state.hasEraser && bodyType.hasEraser)
            {
                Debug.Log("A");
                pencilEraser.ResetValue();
            }
            else if (!state.hasLead && bodyType.hasLead)
            {
                Debug.Log("B");
                pencilLead.ResetValue();
            }
            else if (state.hasLead && !bodyType.hasLead)
            {
                Debug.Log("c");
                pencilLead.SetValue(0, false);
            }
            else if (state.hasEraser && !bodyType.hasEraser)
            {
                Debug.Log("D");
                pencilEraser.SetValue(0, false);
            }

            UpdateState(i);

            break;
        }
    }
}
