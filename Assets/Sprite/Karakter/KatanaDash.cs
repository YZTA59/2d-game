using UnityEngine;

public class KatanaDash : MonoBehaviour {

    public float dashCooldown = 2f;
    private float dashTimer = 0f;
    public bool canIDash = true;
    public Vector2 savedVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () 
    {
        if (dashTimer > 0)
        {
            canIDash = false;
            dashTimer -= Time.deltaTime;
        }
        if (dashTimer <= 0)
        {
            canIDash = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && canIDash)
        {
            // saves velocity prior to dashing
            savedVelocity = rb.linearVelocity;
            // this part is the actual dash itself
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * 3f, rb.linearVelocity.y);
            // sets up a cooldown so you have to wait to dash again
            dashTimer = dashCooldown;
        }
    }
}