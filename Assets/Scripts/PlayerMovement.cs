using System;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [NonSerialized]
    public Player player;

    public float moveSpeed = 2.5f;

    Animator animator;
    Vector2 moveDirection = Vector2.down;
    bool isMoving;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        isMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector2.up);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector2.down);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
        }

        UpdateAnimation();
    }

    void Move(Vector2 direction)
    {
        gameObject.transform.Translate(direction * moveSpeed * Time.deltaTime);
        moveDirection = direction;
        isMoving = true;
    }

    void UpdateAnimation()
    {
        animator.SetBool("isMoving", isMoving);

        animator.SetFloat("horizontalDirection", moveDirection.x);
        animator.SetFloat("verticalDirection", moveDirection.y);

        if (animator.GetInteger("BodyType ID") != player.bodyInfo.bodyTypeID)
        {
            animator.SetInteger("BodyType ID", player.bodyInfo.bodyTypeID);
        }
    }
}
