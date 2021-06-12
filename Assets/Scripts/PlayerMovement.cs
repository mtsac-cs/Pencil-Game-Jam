using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    Animator animator;
    Vector2 moveDirection;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = false;
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            moveDirection = Vector2.up;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            moveDirection = Vector2.left;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            moveDirection = Vector2.down;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            moveDirection = Vector2.right;
            isMoving = true;
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        animator.SetBool("isMoving", isMoving);

        var tempVector = new Vector2(animator.GetFloat("horizontalDirection"), animator.GetFloat("verticalDirection"));
        if (tempVector != moveDirection)
        {
            Debug.Log("position not the same");
            animator.SetFloat("horizontalDirection", moveDirection.x);
            animator.SetFloat("verticalDirection", moveDirection.y);
        }
    }
}
