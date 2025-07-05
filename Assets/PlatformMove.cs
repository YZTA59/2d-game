using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform noktaA, noktaB; // Gidilecek noktalar
    public float hiz = 2f;
    private Vector2 hedef; // DE���T�: Vector3 yerine Vector2 kullan�yoruz

    void Start()
    {
        // Ba�lang��ta B noktas�n�n sadece X ve Y'sini hedef al
        hedef = noktaB.position;
    }

    void Update()
    {
        // Hareketi sadece X ve Y ekseninde hesapla
        Vector2 yeniPozisyon = Vector2.MoveTowards(transform.position, hedef, hiz * Time.deltaTime);

        // Yeni X ve Y'yi uygula ama mevcut Z pozisyonunu koru
        transform.position = new Vector3(yeniPozisyon.x, yeniPozisyon.y, transform.position.z);

        // Hedefe ula��p ula�mad���n� kontrol et
        if (Vector2.Distance(transform.position, hedef) < 0.1f)
        {
            // Hedefleri de�i�tirirken sadece X ve Y pozisyonlar�n� kullan
            Vector2 pozisyonA_2D = noktaA.position;
            Vector2 pozisyonB_2D = noktaB.position;

            hedef = (hedef == pozisyonA_2D) ? pozisyonB_2D : pozisyonA_2D;
        }
    }

    // Bu k�s�mlar ayn� kalabilir
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}