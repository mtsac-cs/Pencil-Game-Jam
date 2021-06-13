using System;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [NonSerialized]
    public Player player;
    public Rigidbody2D rb;
    public float moveSpeed = 2.5f;
    [Range(1, 10)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Animator animator;
    Vector2 moveDirection = Vector2.down;
    bool isMoving;
    private bool isGrounded = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
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
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.up * jumpVelocity;
            }
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
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
