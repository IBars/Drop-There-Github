using UnityEngine;

public class ManualSpawner : MonoBehaviour
{
    public GameObject[] colorBlocks;   // Red, Yellow, Blue, Green
    public Transform spawnPoint;       // SpawnPoint objesi
    public float moveSpeed = 5f;       // sağ-sol hız

    GameObject currentBlock;
    Rigidbody2D currentRb;
    bool isFalling = false;

    void Update()
    {
        // SPAWN / DROP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentBlock == null)
                Spawn();
            else
                Drop();
        }

        // SAĞA - SOLA HAREKET (sadece havadayken)
        if (currentBlock != null && !isFalling)
        {
            float move = Input.GetAxisRaw("Horizontal"); // A-D / ← →
            if (move != 0)
            {
                currentBlock.transform.position +=
                    new Vector3(move * moveSpeed * Time.deltaTime, 0f, 0f);
            }
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

        currentRb = currentBlock.GetComponent<Rigidbody2D>();

        if (currentRb != null)
        {
            currentRb.gravityScale = 0f;              // havada
            currentRb.linearVelocity = Vector2.zero;
        }

        isFalling = false;
    }

    void Drop()
    {
        if (currentRb != null)
        {
            currentRb.gravityScale = 2f; // düş ⬇️
        }

        isFalling = true;
        currentBlock = null;
        currentRb = null;
    }
}
