using UnityEngine;

public class GorselSalinim : MonoBehaviour
{
    [Tooltip("Sal�n�m�n merkez noktas� (zincirin tavana ba�l� oldu�u yer)")]
    public Vector2 merkezNokta = new Vector2(0, 4);

    [Tooltip("Zincirin uzunlu�u")]
    public float salinimYaricapi = 2f;

    [Tooltip("Saniyedeki sal�n�m say�s� gibi d���nebilirsiniz")]
    public float hiz = 1f;

    [Tooltip("Merkezden sa�a ve sola ka� derece a��laca��")]
    public float salinimAcisi = 60f;

    // Dahili zamanlay�c�
    private float zamanlayici;

    void Update()
    {
        // Zaman� s�rekli olarak h�za ba�l� bir �ekilde art�r
        zamanlayici += Time.deltaTime * hiz;

        // Mathf.Sin() fonksiyonu, zamanla -1 ile +1 aras�nda gidip gelen
        // p�r�zs�z bir dalga de�eri �retir.
        float sinDalga = Mathf.Sin(zamanlayici);

        // Bu -1 ile +1 aras�ndaki de�eri, bizim istedi�imiz a�� aral���na �evirelim.
        // �rne�in, -60 ile +60 derece aras�nda gidip gelmesini sa�layal�m.
        float mevcutAci = sinDalga * salinimAcisi;

        // Unity'nin trigonometrik hesaplamalar� radyan kulland��� i�in a��y� radyana �evirelim.
        float radyanAci = mevcutAci * Mathf.Deg2Rad;

        // Yeni pozisyonu hesaplayal�m:
        // Merkez noktan�n etraf�nda, yar��ap kadar uzakta, o anki a��da bir nokta.
        // x = merkez.x + sin(a��) * yar��ap
        // y = merkez.y - cos(a��) * yar��ap (eksi ��nk� 0 derece a�a��y� g�steriyor)
        float x = merkezNokta.x + Mathf.Sin(radyanAci) * salinimYaricapi;
        float y = merkezNokta.y - Mathf.Cos(radyanAci) * salinimYaricapi;

        // Nesnenin pozisyonunu, hesaplad���m�z bu yeni pozisyona her karede e�itleyelim.
        transform.position = new Vector2(x, y);
    }
}