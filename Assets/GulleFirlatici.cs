using UnityEngine;

public class GulleFirlatici : MonoBehaviour
{
    public float firlatmaGucu = 25f;
    private Rigidbody2D rb; // YENÝ: Rigidbody'yi tutmak için bir deðiþken

    // YENÝ BÖLÜM: Bu fonksiyon oyun baþladýðýnda SADECE BÝR KERE çalýþýr
    void Start()
    {
        // Bu script'in baðlý olduðu nesnenin Rigidbody 2D bileþenini bul
        rb = GetComponent<Rigidbody2D>();

        // Eðer Rigidbody varsa...
        if (rb != null)
        {
            // ONU UYANDIR! Bu komut, uyku modundaki fiziði zorla aktif eder.
            rb.WakeUp();
            Debug.Log("Gulle'nin Rigidbody'si baþarýyla uyandýrýldý!");
        }
    }

    // Bu fonksiyon ayný kalýyor
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