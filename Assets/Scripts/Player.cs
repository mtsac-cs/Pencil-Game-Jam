using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PencilPartInfo))]
public class Player : MonoBehaviour
{
    public static readonly string playerTag = "Player";

    public bool InteractKeyDown { get; private set; }

    [NonSerialized]
    public PlayerMovement movement;

    public PencilPartInfo bodyInfo;
    public PencilPartInfo[] bodyTypes;

    void Start()
    {
        //unneeded for now
        //will warn the developer to drag in a value instead
        // if (!bodyInfo)
        // {
        //     bodyInfo = GetComponent<PencilPartInfo>();
        // }
        if(bodyInfo==null){
            Debug.LogError("BodyInfo in player is null please drag in a base body type from Scriptable Objects");
        }
    }

    private void Update()
    {
        InteractKeyDown = Input.GetKey(KeyCode.E);
    }
    public void updatePart(int id){
        if(id>=bodyTypes.Length){
            Debug.LogError("id is out of range (body type you are trying to access does not exist");
            return;
        }
        bodyInfo = bodyTypes[id];
    }
}