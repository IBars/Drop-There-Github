using UnityEngine;

public class ManualSpawner : MonoBehaviour {
    [Header("Red Prefabs")]
    public GameObject redBlock;
    public GameObject redCircle;
    public GameObject redHexagon;
    public GameObject redTriangle;

    [Header("Yellow Prefabs")]
    public GameObject yellowBlock;
    public GameObject yellowCircle;
    public GameObject yellowHexagon;
    public GameObject yellowTriangle;

    public Transform spawnPoint;
    
    GameObject currentBlock;
    Rigidbody2D currentRb;
    bool nextIsYellow = false;
    bool isSpawning = false; // Üst üste spawnlanmayı engellemek için

    void Start() {
        // Oyun başlar başlamaz ilk objeyi oluştur
        Spawn();
    }

    void Update() {
        // Sadece bir obje kontrol ediliyorsa ve Space'e basılırsa
        if (Input.GetKeyDown(KeyCode.Space) && currentBlock != null) {
            Drop();
        }

        // Yatay hareket
        if (currentBlock != null) {
            float h = Input.GetAxisRaw("Horizontal");
            currentBlock.transform.position += new Vector3(h * 5f * Time.deltaTime, 0, 0);
        }
    }

    void Spawn() {
        GameObject[] redBlocks = { redBlock, redCircle, redHexagon, redTriangle };
        GameObject[] yellowBlocks = { yellowBlock, yellowCircle, yellowHexagon, yellowTriangle };

        GameObject prefab;
        if (nextIsYellow) prefab = yellowBlocks[Random.Range(0, yellowBlocks.Length)];
        else prefab = redBlocks[Random.Range(0, redBlocks.Length)];

        nextIsYellow = !nextIsYellow;

        currentBlock = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        currentRb = currentBlock.GetComponent<Rigidbody2D>();
        currentRb.gravityScale = 0f;
        currentRb.linearVelocity = Vector2.zero;
        
        isSpawning = false; 
    }

    void Drop() {
        // Mevcut objeyi serbest bırak
        currentRb.gravityScale = 2f;
        currentBlock = null;
        currentRb = null;

        // 1 saniye sonra Spawn fonksiyonunu otomatik çalıştır
        // Bu süre objenin spawn noktasından uzaklaşması için yeterlidir
        Invoke("Spawn", 1.0f);
    }
}