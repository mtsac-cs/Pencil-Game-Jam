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

    void Start()
    {
        if (!bodyInfo)
        {
            bodyInfo = GetComponent<PencilPartInfo>();
        }
    }

    private void Update()
    {
        InteractKeyDown = Input.GetKey(KeyCode.E);
    }
}