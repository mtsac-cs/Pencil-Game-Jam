using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PencilModel))]
public class Player : MonoBehaviour
{
    public static Player instance;
    public static readonly string playerTag = "Player";
    public bool InteractKeyDown { get; private set; }

    [NonSerialized]
    public PlayerMovement movement;

    [NonSerialized]
    public PencilModel pencilModel;

    void Awake()
    {
        instance = this;
        pencilModel = GetComponent<PencilModel>();
    }

    void Start()
    {

    }

    private void Update()
    {
        InteractKeyDown = Input.GetKey(KeyCode.E);
    }
}