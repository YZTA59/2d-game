using UnityEngine;

public class GulleFirlatici : MonoBehaviour
{
    public float firlatmaGucu = 25f;

    // Güllenin collider'ý "Is Trigger" olduðu için bu fonksiyon çalýþýr
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Çarptýðý nesnenin bir PlayerController'ý var mý diye kontrol et
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Oyuncuyu güllenin merkezinden dýþarý doðru it
                Vector2 firlatmaYonu = (other.transform.position - transform.position).normalized;
                playerRb.AddForce(firlatmaYonu * firlatmaGucu, ForceMode2D.Impulse);
            }
        }
    }
}