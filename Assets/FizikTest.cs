using UnityEngine;

public class FizikTest : MonoBehaviour
{
    private Rigidbody2D rb;
    public float donmeGucu = 100f; // Dilediðin bir kuvvet

    void Start()
    {
        // Nesnenin Rigidbody'sini bul
        rb = GetComponent<Rigidbody2D>();

        // Konsola testin baþladýðýný yazdýr
        Debug.Log("Fizik Testi Baþladý! Nesneye tork uygulanýyor...");
    }

    void FixedUpdate()
    {
        // Her fizik karesinde, nesneye bir dönme kuvveti (tork) uygula
        rb.AddTorque(donmeGucu);
    }
}