using UnityEngine;

public class GulleFirlatici : MonoBehaviour
{
    public float firlatmaGucu = 25f;

    // G�llenin collider'� "Is Trigger" oldu�u i�in bu fonksiyon �al���r
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �arpt��� nesnenin bir PlayerController'� var m� diye kontrol et
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Oyuncuyu g�llenin merkezinden d��ar� do�ru it
                Vector2 firlatmaYonu = (other.transform.position - transform.position).normalized;
                playerRb.AddForce(firlatmaYonu * firlatmaGucu, ForceMode2D.Impulse);
            }
        }
    }
}