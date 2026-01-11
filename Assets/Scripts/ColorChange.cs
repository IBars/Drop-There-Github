using UnityEngine;

public class HassasRenkGecisi : MonoBehaviour
{
    private Renderer objRenderer;
    private Color hedefRenk;
    private Color baslangicRengi;
    
    [Range(0.1f, 5f)]
    public float degisimHizi = 1.0f; // Ne kadar sürede değişeceği
    private float sayac = 0f;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        // Başlangıçta rastgele iki renk belirle
        baslangicRengi = objRenderer.material.color;
        hedefRenk = Random.ColorHSV();
    }

    void Update()
    {
        // Zamanı hassas bir şekilde takip et
        sayac += Time.deltaTime * degisimHizi;

        // Rengi iki nokta arasında matematiksel olarak yumuşat
        objRenderer.material.color = Color.Lerp(baslangicRengi, hedefRenk, sayac);

        // Geçiş tamamlandığında (sayac 1'e ulaştığında)
        if (sayac >= 1.0f)
        {
            sayac = 0f; // Sayacı sıfırla
            baslangicRengi = objRenderer.material.color; // Mevcut rengi başlangıç yap
            hedefRenk = Random.ColorHSV(); // Yeni bir hedef renk seç
        }
    }
}