using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(BodyType))]
public class PlayerMovement : MonoBehaviour
{
    [NonSerialized]
    public BodyType body;

    public float moveSpeed = 5;    

    Animator animator;
    Vector2 moveDirection = Vector2.down;
    bool isMoving;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<BodyType>();
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

        if (animator.GetInteger("BodyType ID") != body.bodyId)
        {
            animator.SetInteger("BodyType ID", body.bodyId);
        }
    }
}
