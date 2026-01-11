using UnityEngine;

public class ManualSpawner : MonoBehaviour
{
    public GameObject[] colorBlocks;   // Red, Yellow, Blue, Green prefabları
    public Transform spawnPoint;       // SpawnPoint GameObject

    GameObject currentBlock;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentBlock == null)
                Spawn();
            else
                Drop();
        }
    }

    void Spawn()
    {
        if (colorBlocks.Length == 0 || spawnPoint == null)
        {
            Debug.LogError("ColorBlocks veya SpawnPoint eksik!");
            return;
        }

        int rand = Random.Range(0, colorBlocks.Length);
        currentBlock = Instantiate(
            colorBlocks[rand],
            spawnPoint.position,
            Quaternion.identity
        );
    }

    void Drop()
    {
        // Şimdilik sadece kilitliyoruz
        currentBlock = null;
    }
}
