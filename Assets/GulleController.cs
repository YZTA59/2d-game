using UnityEngine;

public class GulleController : MonoBehaviour
{
    public Transform noktaA, noktaB;
    public float hiz = 4f;
    public float firlatmaGucu = 25f;
    private Vector3 hedef;

    void Start()
    {
        hedef = noktaB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, hedef, hiz * Time.deltaTime);
        if (Vector3.Distance(transform.position, hedef) < 0.1f)
        {
            hedef = (hedef == noktaA.position) ? noktaB.position : noktaA.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarptýðý nesnenin bir PlayerController script'i varsa...
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 firlatmaYonu = (other.transform.position - transform.position).normalized;
                playerRb.AddForce(firlatmaYonu * firlatmaGucu, ForceMode2D.Impulse);
            }
        }
    }
}