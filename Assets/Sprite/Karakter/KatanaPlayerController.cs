using UnityEngine;

public class KatanaPlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    public float jumpForce = 10f;
    public float dashForce = 15f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        animator.SetBool("isRunning", move != 0);

        // Flip
        if (move > 0) spriteRenderer.flipX = false;
        else if (move < 0) spriteRenderer.flipX = true;

        // Hareket
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Zıplama
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("isDashing");
            rb.linearVelocity = new Vector2((spriteRenderer.flipX ? -1 : 1) * dashForce, rb.linearVelocity.y);
        }

        // Saldırı
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (move != 0)
                animator.SetTrigger("isRunAttacking");
            else
                animator.SetTrigger("isAttacking");
        }

        // Düşme animasyonu kontrolü
        if (!isGrounded && rb.linearVelocity.y < 0)
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }
}
