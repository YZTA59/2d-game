using UnityEngine;

public class GulleFirlatici : MonoBehaviour
{
    public float firlatmaGucu = 25f;
    private Rigidbody2D rb; // YEN�: Rigidbody'yi tutmak i�in bir de�i�ken

    // YEN� B�L�M: Bu fonksiyon oyun ba�lad���nda SADECE B�R KERE �al���r
    void Start()
    {
        // Bu script'in ba�l� oldu�u nesnenin Rigidbody 2D bile�enini bul
        rb = GetComponent<Rigidbody2D>();

        // E�er Rigidbody varsa...
        if (rb != null)
        {
            // ONU UYANDIR! Bu komut, uyku modundaki fizi�i zorla aktif eder.
            rb.WakeUp();
            Debug.Log("Gulle'nin Rigidbody'si ba�ar�yla uyand�r�ld�!");
        }
    }

    // Bu fonksiyon ayn� kal�yor
    private void OnTriggerEnter2D(Collider2D other)
    {
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