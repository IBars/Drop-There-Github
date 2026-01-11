using UnityEngine;

public class ManualSpawner : MonoBehaviour
{
    public GameObject redBlock;
    public GameObject yellowBlock;
    public Transform spawnPoint;

    GameObject currentBlock;
    Rigidbody2D currentRb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentBlock == null)
                Spawn();
            else
                Drop();
        }

        if (currentBlock != null)
        {
            float h = Input.GetAxisRaw("Horizontal");
            currentBlock.transform.position += new Vector3(h * 5f * Time.deltaTime, 0, 0);
        }
    }

    void Spawn()
    {
        GameObject prefab = Random.Range(0, 2) == 0 ? redBlock : yellowBlock;

        currentBlock = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        currentRb = currentBlock.GetComponent<Rigidbody2D>();

        currentRb.gravityScale = 0f;
        currentRb.linearVelocity = Vector2.zero;
    }

    void Drop()
    {
        currentRb.gravityScale = 2f;
        currentBlock = null;
        currentRb = null;
    }
}
