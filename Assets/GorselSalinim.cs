using UnityEngine;

public class GorselSalinim : MonoBehaviour
{
    [Tooltip("Salýnýmýn merkez noktasý (zincirin tavana baðlý olduðu yer)")]
    public Vector2 merkezNokta = new Vector2(0, 4);

    [Tooltip("Zincirin uzunluðu")]
    public float salinimYaricapi = 2f;

    [Tooltip("Saniyedeki salýným sayýsý gibi düþünebilirsiniz")]
    public float hiz = 1f;

    [Tooltip("Merkezden saða ve sola kaç derece açýlacaðý")]
    public float salinimAcisi = 60f;

    // Dahili zamanlayýcý
    private float zamanlayici;

    void Update()
    {
        // Zamaný sürekli olarak hýza baðlý bir þekilde artýr
        zamanlayici += Time.deltaTime * hiz;

        // Mathf.Sin() fonksiyonu, zamanla -1 ile +1 arasýnda gidip gelen
        // pürüzsüz bir dalga deðeri üretir.
        float sinDalga = Mathf.Sin(zamanlayici);

        // Bu -1 ile +1 arasýndaki deðeri, bizim istediðimiz açý aralýðýna çevirelim.
        // Örneðin, -60 ile +60 derece arasýnda gidip gelmesini saðlayalým.
        float mevcutAci = sinDalga * salinimAcisi;

        // Unity'nin trigonometrik hesaplamalarý radyan kullandýðý için açýyý radyana çevirelim.
        float radyanAci = mevcutAci * Mathf.Deg2Rad;

        // Yeni pozisyonu hesaplayalým:
        // Merkez noktanýn etrafýnda, yarýçap kadar uzakta, o anki açýda bir nokta.
        // x = merkez.x + sin(açý) * yarýçap
        // y = merkez.y - cos(açý) * yarýçap (eksi çünkü 0 derece aþaðýyý gösteriyor)
        float x = merkezNokta.x + Mathf.Sin(radyanAci) * salinimYaricapi;
        float y = merkezNokta.y - Mathf.Cos(radyanAci) * salinimYaricapi;

        // Nesnenin pozisyonunu, hesapladýðýmýz bu yeni pozisyona her karede eþitleyelim.
        transform.position = new Vector2(x, y);
    }
}