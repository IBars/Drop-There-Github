using UnityEngine;

public class ParlaklikGecisi : MonoBehaviour
{
    private Renderer objRenderer;
    private Color anaRenk;
    
    [Header("Ayarlar")]
    public float gecisHizi = 2.0f; // Ne kadar hızlı değişeceği
    [Range(0f, 1f)] public float minParlaklik = 0.2f; // En karanlık hal (0 = Siyah)
    [Range(0f, 1f)] public float maxParlaklik = 1.0f; // En açık hal (1 = Tam Parlak)

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        // Objenin başlangıçtaki orijinal rengini kaydet
        anaRenk = objRenderer.material.color;
    }

    void Update()
    {
        float h, s, v;
        // Mevcut rengi HSV formatına dönüştür (Hue, Saturation, Value)
        Color.RGBToHSV(anaRenk, out h, out s, out v);

        // Sinüs dalgası kullanarak 0 ile 1 arasında yumuşak bir salınım oluştur
        // Mathf.PingPong da kullanılabilir ama Sin daha organiktir
        float t = (Mathf.Sin(Time.time * gecisHizi) + 1.0f) / 2.0f;
        
        // Parlaklığı (v) belirlediğimiz min ve max değerleri arasında değiştir
        v = Mathf.Lerp(minParlaklik, maxParlaklik, t);

        // Yeni rengi geri yükle ve uygula
        objRenderer.material.color = Color.HSVToRGB(h, s, v);
    }
}