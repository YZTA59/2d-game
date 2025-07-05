using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Oyuncu ayarlar�
    public float hareketHizi = 8f;
    public float ziplamaGucu = 1f;

    // Dahili de�i�kenler
    private Rigidbody2D rb;
    private float hareketYonu;

    // Oyuncu ID'si - Multiplayer i�in daha sonra kullanaca��z
    public int oyuncuNumarasi = 1;

    // Tu� atamalar�
    private KeyCode solTus, sagTus, ziplamaTusu;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Oyuncu numaras�na g�re tu�lar� ata
        TuslariAta();
    }

    void Update()
    {
        // Tu� girdilerini al
        if (Input.GetKey(solTus))
        {
            hareketYonu = -1;
        }
        else if (Input.GetKey(sagTus))
        {
            hareketYonu = 1;
        }
        else
        {
            hareketYonu = 0;
        }

        // Z�plama
        if (Input.GetKeyDown(ziplamaTusu) && Mathf.Abs(rb.linearVelocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Hareketi uygula
        rb.linearVelocity = new Vector2(hareketYonu * hareketHizi, rb.linearVelocity.y);
    }

    void TuslariAta()
    {
        if (oyuncuNumarasi == 1)
        {
            solTus = KeyCode.A;
            sagTus = KeyCode.D;
            ziplamaTusu = KeyCode.W;
        }
        else if (oyuncuNumarasi == 2)
        {
            solTus = KeyCode.J;
            sagTus = KeyCode.L;
            ziplamaTusu = KeyCode.I;
        }
        else if (oyuncuNumarasi == 3)
        {
            solTus = KeyCode.LeftArrow;
            sagTus = KeyCode.RightArrow;
            ziplamaTusu = KeyCode.UpArrow;
        }
        else if (oyuncuNumarasi == 4)
        {
            solTus = KeyCode.Keypad4;
            sagTus = KeyCode.Keypad6;
            ziplamaTusu = KeyCode.Keypad8;
        }
    }
}