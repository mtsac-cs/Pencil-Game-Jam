using System;
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

    public bool HasEraserModel() => state.hasEraserModel;

    public bool HasLeadModel() => state.hasLeadModel;

    public void UpdateModel()
    {
        if(pencilEraser.StatValue <= 0 && pencilLead.StatValue <= 0)
        {
            UpdateState(0);
        }
        else if(pencilEraser.StatValue > 0 && pencilLead.StatValue <= 0)
        {
            UpdateState(2);
        }
        else if(pencilEraser.StatValue <= 0 && pencilLead.StatValue > 0)
        {
            UpdateState(1);
        }
        else if(pencilEraser.StatValue > 0 && pencilLead.StatValue > 0)
        {
            UpdateState(3);
        }
        else
        {
            //no need to update if he is complete
        }
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
}