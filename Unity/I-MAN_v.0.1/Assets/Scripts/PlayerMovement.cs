using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask ladderLayer;

    public float horizontal;
    public float vertical;
    private float speed = 8f;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;
    public Animator animator;
    private bool isGrounded;
    //para ladder...


    private bool isLadder;
    private bool isClimbing;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("isGrounded", isGrounded);
        if (!isFacingRight && horizontal > 0f)
        {

            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (context.canceled && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    /*private bool IsGrounded()
    {
        return isGrounded= Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }*/

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }


    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1.7f;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            animator.SetBool("isLadder", isLadder);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            animator.SetBool("isLadder", isLadder);
        }
    }
}