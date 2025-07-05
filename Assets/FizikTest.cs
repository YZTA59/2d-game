using UnityEngine;

public class FizikTest : MonoBehaviour
{
    private Rigidbody2D rb;
    public float donmeGucu = 100f; // Diledi�in bir kuvvet

    void Start()
    {
        // Nesnenin Rigidbody'sini bul
        rb = GetComponent<Rigidbody2D>();

        // Konsola testin ba�lad���n� yazd�r
        Debug.Log("Fizik Testi Ba�lad�! Nesneye tork uygulan�yor...");
    }

    void FixedUpdate()
    {
        // Her fizik karesinde, nesneye bir d�nme kuvveti (tork) uygula
        rb.AddTorque(donmeGucu);
    }
}