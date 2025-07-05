using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform noktaA, noktaB; // Gidilecek noktalar
    public float hiz = 2f;
    private Vector2 hedef; // DEÐÝÞTÝ: Vector3 yerine Vector2 kullanýyoruz

    void Start()
    {
        // Baþlangýçta B noktasýnýn sadece X ve Y'sini hedef al
        hedef = noktaB.position;
    }

    void Update()
    {
        // Hareketi sadece X ve Y ekseninde hesapla
        Vector2 yeniPozisyon = Vector2.MoveTowards(transform.position, hedef, hiz * Time.deltaTime);

        // Yeni X ve Y'yi uygula ama mevcut Z pozisyonunu koru
        transform.position = new Vector3(yeniPozisyon.x, yeniPozisyon.y, transform.position.z);

        // Hedefe ulaþýp ulaþmadýðýný kontrol et
        if (Vector2.Distance(transform.position, hedef) < 0.1f)
        {
            // Hedefleri deðiþtirirken sadece X ve Y pozisyonlarýný kullan
            Vector2 pozisyonA_2D = noktaA.position;
            Vector2 pozisyonB_2D = noktaB.position;

            hedef = (hedef == pozisyonA_2D) ? pozisyonB_2D : pozisyonA_2D;
        }
    }

    // Bu kýsýmlar ayný kalabilir
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}