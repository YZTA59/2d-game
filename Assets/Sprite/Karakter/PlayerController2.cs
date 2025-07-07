using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Punch"))
        {
            // Yürüme
            float move = Input.GetAxisRaw("Horizontal");
            animator.SetBool("isWalking", move != 0);

            // Karakteri hareket ettir
            Vector3 movement = new Vector3(move, 0, 0) * speed * Time.deltaTime;
            transform.position += movement;

            // Flip işlemi
            if (move > 0)
                spriteRenderer.flipX = false; // Sağ
            else if (move < 0)
                spriteRenderer.flipX = true;  // Sol

            // Yumruk
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Punch");
            }
        }
    }
}
