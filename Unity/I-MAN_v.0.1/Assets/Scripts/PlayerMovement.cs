using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float horizontal;
    private float speed = 8f;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;
    public Animator animator;
    private bool isGrounded;

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
        else if (isFacingRight && horizontal <0f)
        {
            Flip();
        }
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (context.canceled && rb.velocity.y >0)
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

        
    }
}

